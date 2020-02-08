using System;
using System.Collections.Generic;
using System.Reflection;
using rNascarTS.Models;

namespace rNascarTS.Factories
{
    class ViewDataSourceFactory
    {
        #region public

        public IList<ViewDataSource> GetList()
        {
            IList<ViewDataSource> sources = new List<ViewDataSource>();

            var liveFeed = new NascarApi.Models.LiveFeed.RootObject();
            var liveFeedType = liveFeed.GetType();
            var liveFeedDataSource = GetDataSource("LiveFeedData", liveFeedType);
            sources.Add(liveFeedDataSource);

            var liveFlag = new NascarApi.Models.LiveFlagData.RootObject();
            var liveFlagType = liveFlag.GetType();
            var liveFlagDataSource = GetDataSource("LiveFlagData[]", liveFlagType);
            sources.Add(liveFlagDataSource);

            var livePoints = new NascarApi.Models.LivePoints.RootObject();
            var livePointsType = livePoints.GetType();
            var livePointsDataSource = GetDataSource("LivePointsData[]", livePointsType);
            sources.Add(livePointsDataSource);

            return sources;
        }

        #endregion

        #region protected

        protected virtual ViewDataSource GetDataSource(string name, Type dataSourceType)
        {
            ViewDataSource source = new ViewDataSource()
            {
                Name = name,
                Type = dataSourceType.FullName,
                AssemblyQualifiedName = dataSourceType.AssemblyQualifiedName
            };

            foreach (PropertyInfo propertyInfo in dataSourceType.GetProperties())
            {
                if (propertyInfo.PropertyType.Name.Contains("List"))
                {
                    var innerSource = GetDataSource(propertyInfo);
                    source.Lists.Add(innerSource);
                }
                else if (propertyInfo.PropertyType.Assembly == dataSourceType.Assembly)
                {
                    var innerSource = GetDataSource(propertyInfo);
                    source.NestedClasses.Add(innerSource);
                }
                else
                {
                    source.Fields.Add(new ViewDataMember()
                    {
                        Name = propertyInfo.Name,
                        Type = propertyInfo.PropertyType.ToString(),
                        AssemblyQualifiedName = propertyInfo.PropertyType.AssemblyQualifiedName
                    });
                }
            }

            return source;
        }

        protected virtual ViewDataSource GetDataSource(PropertyInfo sourcePropertyInfo)
        {
            ViewDataSource source = null;

            if (sourcePropertyInfo.PropertyType.IsGenericType)
            {
                source = new ViewDataSource()
                {
                    Name = sourcePropertyInfo.Name,
                    Type = sourcePropertyInfo.PropertyType.GenericTypeArguments[0].Name,
                    AssemblyQualifiedName = sourcePropertyInfo.PropertyType.GenericTypeArguments[0].AssemblyQualifiedName
                };
            }
            else
            {
                source = new ViewDataSource()
                {
                    Name = sourcePropertyInfo.Name,
                    Type = sourcePropertyInfo.PropertyType.Name,
                    AssemblyQualifiedName = sourcePropertyInfo.PropertyType.AssemblyQualifiedName
                };
            }

            var dataSourceType = Type.GetType(source.AssemblyQualifiedName);

            foreach (PropertyInfo propertyInfo in dataSourceType.GetProperties())
            {
                if (propertyInfo.PropertyType.Name.Contains("List"))
                {
                    var innerSource = GetDataSource(propertyInfo);
                    source.Lists.Add(innerSource);
                }
                else if (propertyInfo.PropertyType.Assembly == dataSourceType.Assembly)
                {
                    var innerSource = GetDataSource(propertyInfo);
                    source.NestedClasses.Add(innerSource);
                }
                else
                {
                    source.Fields.Add(new ViewDataMember()
                    {
                        Name = propertyInfo.Name,
                        Type = propertyInfo.PropertyType.ToString(),
                        AssemblyQualifiedName = propertyInfo.PropertyType.AssemblyQualifiedName
                    });
                }
            }

            return source;
        }

        #endregion

    }
}
