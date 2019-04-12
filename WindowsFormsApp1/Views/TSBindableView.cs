using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace rNascarTimingAndScoring.Views
{
    public partial class TSBindableView : UserControl
    {
        private ListChangedEventHandler listChangedHandler;
        private EventHandler positionChangedHandler;

        private object dataSource;
        private string dataMember;
        private CurrencyManager dataManager;

        [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")]
        [Category("Data")]
        [DefaultValue(null)]
        public object DataSource
        {
            get
            {
                return this.dataSource;
            }
            set
            {
                if (this.dataSource != value)
                {
                    this.dataSource = value;
                    tryDataBinding();
                }
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design",
            "System.Drawing.Design.UITypeEditor,System.Drawing")]
        [DefaultValue("")]
        public string DataMember
        {
            get
            {
                return this.dataMember;
            }
            set
            {
                if (this.dataMember != value)
                {
                    this.dataMember = value;
                    tryDataBinding();
                }
            }
        }

        private IList<TSGridRow> _items;
        public IList<TSGridRow> Items
        {
            get
            {
                return pnlGrid.Controls.OfType<TSGridRow>().ToList();
            }
            set
            {
                _items = value;
            }
        }

        public TSBindableView()
        {
            InitializeComponent();

            listChangedHandler = new ListChangedEventHandler(dataManager_ListChanged);
            positionChangedHandler = new EventHandler(dataManager_PositionChanged);
        }

        protected override void OnBindingContextChanged(EventArgs e)
        {
            this.tryDataBinding();
            base.OnBindingContextChanged(e);
        }

        private void updateAllData()
        {
            this.Items.Clear();
            for (int i = 0; i < dataManager.Count; i++)
            {
                addItem(i);
            }
        }

        private void addItem(int index)
        {
            //ListViewItem item = getListViewItem(index);
            //this.Items.Insert(index, item);
            TSGridRow item = getTSGridRow(index);
            pnlGrid.Controls.Add(item);
        }

        private void updateItem(int index)
        {
            if (index >= 0 &&
                index < this.Items.Count)
            {
                //ListViewItem item = getListViewItem(index);
                //this.Items[index] = item;
                TSGridRow item = getTSGridRow(index);
                this.Items[index] = item;
                //pnlGrid.Controls[index] = item;
            }
        }

        private void deleteItem(int index)
        {
            if (index >= 0 &&
                index < this.Items.Count)
                this.Items.RemoveAt(index);
        }

        //private ListViewItem getListViewItem(int index)
        //{
        //    object row = dataManager.List[index];
        //    PropertyDescriptorCollection propColl =
        //            dataManager.GetItemProperties();
        //    ArrayList items = new ArrayList();

        //    // Fill value for each column
        //    foreach (ColumnHeader column in this.Columns)
        //    {
        //        PropertyDescriptor prop = null;
        //        prop = propColl.Find(column.Text, false);
        //        if (prop != null)
        //        {
        //            items.Add(prop.GetValue(row).ToString());
        //        }
        //    }
        //    return new ListViewItem((string[])items.ToArray(typeof(string)));
        //}

        private TSGridRow getTSGridRow(int index)
        {
            object row = dataManager.List[index];

            PropertyDescriptorCollection propColl =
                    dataManager.GetItemProperties();

            ArrayList items = new ArrayList();

            // Fill value for each column
            //foreach (ColumnHeader column in this.Columns)
            //{
            //    PropertyDescriptor prop = null;
            //    prop = propColl.Find(column.Text, false);
            //    if (prop != null)
            //    {
            //        items.Add(prop.GetValue(row).ToString());
            //    }
            //}

            return new TSGridRow();
        }

        private void tryDataBinding()
        {
            if (this.DataSource == null ||
                base.BindingContext == null)
                return;

            CurrencyManager cm;
            try
            {
                cm = (CurrencyManager)
                      base.BindingContext[this.DataSource,
                                          this.DataMember];
            }
            catch (System.ArgumentException)
            {
                // If no CurrencyManager was found
                return;
            }

            if (this.dataManager != cm)
            {
                // Unwire the old CurrencyManager
                if (this.dataManager != null)
                {
                    this.dataManager.ListChanged -=
                                listChangedHandler;
                    this.dataManager.PositionChanged -=
                                positionChangedHandler;
                }
                this.dataManager = cm;
                // Wire the new CurrencyManager
                if (this.dataManager != null)
                {
                    this.dataManager.ListChanged +=
                                listChangedHandler;
                    this.dataManager.PositionChanged +=
                                positionChangedHandler;
                }

                // Update metadata and data
                //calculateColumns();
                updateAllData();
            }
        }

        private void dataManager_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.Reset ||
            e.ListChangedType == ListChangedType.ItemMoved)
            {
                // Update all data
                updateAllData();
            }
            else if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                // Add new Item
                addItem(e.NewIndex);
            }
            else if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                // Change Item
                updateItem(e.NewIndex);
            }
            else if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                // Delete Item
                deleteItem(e.NewIndex);
            }
            else
            {
                // Update metadata and all data
                //calculateColumns();
                updateAllData();
            }
        }

        private void dataManager_PositionChanged(object sender, EventArgs e)
        {
            //if (this.Items.Count > dataManager.Position)
            //{
            //    this.Items[dataManager.Position].Selected = true;
            //    this.EnsureVisible(dataManager.Position);
            //}
        }
    }
}
