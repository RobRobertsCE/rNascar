using System.Collections.Generic;

namespace rNascarTimingAndScoring
{
   

    public class EventFactory
    {
        public List<ScheduledEvent> BuildCupSchedule()
        {
            var events = new List<ScheduledEvent>();

            events.Add(new ScheduledEvent() { series = 1, id = 4770, track = "Daytona International Speedway", name = "Advance Auto Parts Clash", date = "Sunday, Feb 10 3:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4771, track = "Daytona International Speedway", name = "Gander RV Duel 1 At DAYTONA", date = "Thursday, Feb 14 7:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4772, track = "Daytona International Speedway", name = "Gander RV Duel 2 At DAYTONA", date = "Thursday, Feb 14 9:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4773, track = "Daytona International Speedway", name = "DAYTONA 500", date = "Sunday, Feb 17 2:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4774, track = "Atlanta Motor Speedway", name = "Folds of Honor QuikTrip 500", date = "Sunday, Feb 24 2:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4775, track = "Las Vegas Motor Speedway", name = "Pennzoil 400 presented by Jiffy Lube", date = "Sunday, Mar 3 3:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4776, track = "ISM Raceway", name = "TicketGuardian 500", date = "Sunday, Mar 10 3:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4777, track = "Auto Club Speedway", name = "Auto Club 400", date = "Sunday, Mar 17 3:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4778, track = "Martinsville Speedway", name = "STP 500", date = "Sunday, Mar 24 2:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4779, track = "Texas Motor Speedway", name = "O’Reilly Auto Parts 500", date = "Sunday, Mar 31 3:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4780, track = "Bristol Motor Speedway", name = "Food City 500", date = "Sunday, Apr 7 2:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4781, track = "Richmond Raceway", name = "TOYOTA OWNERS 400", date = "Saturday, Apr 13 7:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4782, track = "Talladega Superspeedway", name = "GEICO 500", date = "Sunday, Apr 28 2:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4783, track = "Dover International Speedway", name = "Gander RV 400", date = "Sunday, May 5 2:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4784, track = "Kansas Speedway", name = "Monster Energy NASCAR Cup Series Race at Kansas", date = "Saturday, May 11 7:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4785, track = "Charlotte Motor Speedway", name = "Monster Energy Open", date = "Saturday, May 18 6:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4786, track = "Charlotte Motor Speedway", name = "Monster Energy NASCAR All-Star Race", date = "Saturday, May 18 8:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4787, track = "Charlotte Motor Speedway", name = "Coca-Cola 600", date = "Sunday, May 26 6:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4788, track = "Pocono Raceway", name = "Pocono 400", date = "Sunday, Jun 2 2:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4789, track = "Michigan International Speedway", name = "FireKeepers Casino 400", date = "Sunday, Jun 9 2:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4790, track = "Sonoma Raceway", name = "Toyota / Save Mart 350", date = "Sunday, Jun 23 3:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4791, track = "Chicagoland Speedway", name = "Camping World 400", date = "Sunday, Jun 30 3:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4792, track = "Daytona International Speedway", name = "Coke Zero Sugar 400", date = "Saturday, Jul 6 7:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4793, track = "Kentucky Speedway", name = "Quaker State 400 Presented by Walmart", date = "Saturday, Jul 13 7:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4794, track = "New Hampshire Motor Speedway", name = "Foxwoods Resort Casino 301", date = "Sunday, Jul 21 3:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4795, track = "Pocono Raceway", name = "Gander RV 400", date = "Sunday, Jul 28 3:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4796, track = "Watkins Glen International", name = "Go Bowling at The Glen", date = "Sunday, Aug 4 3:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4797, track = "Michigan International Speedway", name = "Consumers Energy 400", date = "Sunday, Aug 11 3:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4798, track = "Bristol Motor Speedway", name = "Bass Pro Shops NRA Night Race", date = "Saturday, Aug 17 7:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4799, track = "Darlington Raceway", name = "Bojangles’ Southern 500", date = "Sunday, Sep 1 6:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4800, track = "Indianapolis Motor Speedway", name = "Big Machine Vodka 400 at the Brickyard", date = "Sunday, Sep 8 2:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4801, track = "Las Vegas Motor Speedway", name = "*South Point 400", date = "Sunday, Sep 15 7:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4802, track = "Richmond Raceway", name = "*Federated Auto Parts 400", date = "Saturday, Sep 21 7:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4803, track = "Charlotte Motor Speedway Road Course", name = "*Bank of America ROVAL 400", date = "Sunday, Sep 29 2:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4804, track = "Dover International Speedway", name = "*Monster Energy NASCAR Cup Series Race at Dover", date = "Sunday, Oct 6 2:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4805, track = "Talladega Superspeedway", name = "*1000Bulbs.com 500", date = "Sunday, Oct 13 2:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4806, track = "Kansas Speedway", name = "*Hollywood Casino 400", date = "Sunday, Oct 20 2:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4807, track = "Martinsville Speedway", name = "*First Data 500", date = "Sunday, Oct 27 3:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4808, track = "Texas Motor Speedway", name = "*AAA Texas 500", date = "Sunday, Nov 3 3:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4809, track = "ISM Raceway", name = "*Monster Energy NASCAR Cup Series Race at ISM Raceway", date = "Sunday, Nov 10 2:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 1, id = 4810, track = "Homestead-Miami Speedway", name = "*Ford EcoBoost 400", date = "Sunday, Nov 17 3:00:00 PM" });

            return events;
        }

        public List<ScheduledEvent> BuildXFinitySchedule()
        {
            var events = new List<ScheduledEvent>();

            events.Add(new ScheduledEvent() { series = 2, id = 4811, track = "Daytona International Speedway", name = "NASCAR Racing Experience 300", date = "Saturday, Feb 16 2:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4812, track = "Atlanta Motor Speedway", name = "Rinnai 250", date = "Saturday, Feb 23 2:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4813, track = "Las Vegas Motor Speedway", name = "Boyd Gaming 300", date = "Saturday, Mar 2 4:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4814, track = "ISM Raceway", name = "iK9 Service Dog 200 at ISM Raceway", date = "Saturday, Mar 9 4:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4815, track = "Auto Club Speedway", name = "Production Alliance Group 300", date = "Saturday, Mar 16 5:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4816, track = "Texas Motor Speedway", name = "My Bariatric Solutions 300", date = "Saturday, Mar 30 1:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4817, track = "Bristol Motor Speedway", name = "Alsco 300", date = "Saturday, Apr 6 1:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4818, track = "Richmond Raceway", name = "ToyotaCare 250", date = "Friday, Apr 12 7:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4819, track = "Talladega Superspeedway", name = "MoneyLion 300", date = "Saturday, Apr 27 1:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4820, track = "Dover International Speedway", name = "Allied Steel Buildings 200", date = "Saturday, May 4 1:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4821, track = "Charlotte Motor Speedway", name = "Alsco 300", date = "Saturday, May 25 1:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4822, track = "Pocono Raceway", name = "Pocono Green 250 Recycled by J.P. Mascaro & Sons", date = "Saturday, Jun 1 1:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4823, track = "Michigan International Speedway", name = "LTi Printing 250", date = "Saturday, Jun 8 1:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4824, track = "Iowa Speedway", name = "NASCAR Xfinity Series Race at Iowa", date = "Sunday, Jun 16 5:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4825, track = "Chicagoland Speedway", name = "Camping World 300", date = "Saturday, Jun 29 3:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4826, track = "Daytona International Speedway", name = "Circle K Firecracker 250 Powered by Coca-Cola", date = "Friday, Jul 5 7:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4827, track = "Kentucky Speedway", name = "Alsco 300", date = "Friday, Jul 12 7:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4828, track = "New Hampshire Motor Speedway", name = "Lakes Region 200", date = "Saturday, Jul 20 4:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4829, track = "Iowa Speedway", name = "U.S. Cellular 250", date = "Saturday, Jul 27 5:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4830, track = "Watkins Glen International", name = "Zippo 200 at The Glen", date = "Saturday, Aug 3 3:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4831, track = "Mid-Ohio Sports Car Course", name = "B&L Transport 170 at Mid-Ohio", date = "Saturday, Aug 10 3:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4832, track = "Bristol Motor Speedway", name = "Food City 300", date = "Friday, Aug 16 7:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4833, track = "Road America", name = "NASCAR Xfinity Series Race at Road America", date = "Saturday, Aug 24 3:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4834, track = "Darlington Raceway", name = "Sport Clips Haircuts VFW 200", date = "Saturday, Aug 31 4:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4835, track = "Indianapolis Motor Speedway", name = "Indiana 250", date = "Saturday, Sep 7 4:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4836, track = "Las Vegas Motor Speedway", name = "DC Solar 300", date = "Saturday, Sep 14 7:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4837, track = "Richmond Raceway", name = "*GoBowling 250", date = "Friday, Sep 20 7:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4838, track = "Charlotte Motor Speedway Road Course", name = "*Drive for the Cure 200 presented by Blue Cross Blue Shield of North Carolina", date = "Saturday, Sep 28 3:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4839, track = "Dover International Speedway", name = "*NASCAR Xfinity Series Race at Dover", date = "Saturday, Oct 5 3:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4840, track = "Kansas Speedway", name = "*Kansas Lottery 300", date = "Saturday, Oct 19 3:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4841, track = "Texas Motor Speedway", name = "*O’Reilly Auto Parts 300", date = "Saturday, Nov 2 8:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4842, track = "ISM Raceway", name = "*NASCAR Xfinity Series Race at ISM Raceway", date = "Saturday, Nov 9 3:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 2, id = 4843, track = "Homestead-Miami Speedway", name = "*Ford EcoBoost 300", date = "Saturday, Nov 16 3:30:00 PM" });

            return events;
        }

        public List<ScheduledEvent> BuildTruckSchedule()
        {
            var events = new List<ScheduledEvent>();

            events.Add(new ScheduledEvent() { series = 3, id = 4884, track = "Daytona International Speedway", name = "NextEra Energy 250", date = "Friday, Feb 15 7:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4885, track = "Atlanta Motor Speedway", name = "Ultimate Tailgating 200", date = "Saturday, Feb 23 4:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4886, track = "Las Vegas Motor Speedway", name = "Strat 200", date = "Friday, Mar 1 9:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4887, track = "Martinsville Speedway", name = "TrüNorth Global 250", date = "Saturday, Mar 23 2:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4888, track = "Texas Motor Speedway", name = "Vankor 350", date = "Friday, Mar 29 9:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4889, track = "Dover International Speedway", name = "JEGS 200", date = "Friday, May 3 5:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4890, track = "Kansas Speedway", name = "NASCAR Gander Outdoors Truck Series Race at Kansas", date = "Friday, May 10 8:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4891, track = "Charlotte Motor Speedway", name = "North Carolina Education Lottery 200", date = "Friday, May 17 8:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4892, track = "Texas Motor Speedway", name = "Rattlesnake 400", date = "Friday, Jun 7 9:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4893, track = "Iowa Speedway", name = "NASCAR Gander Outdoors Truck Series Race at Iowa", date = "Saturday, Jun 15 8:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4894, track = "Gateway Motorsports Park", name = "Gateway 200 presented by CK Power", date = "Saturday, Jun 22 10:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4895, track = "Chicagoland Speedway", name = "Camping World 225", date = "Friday, Jun 28 9:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4896, track = "Kentucky Speedway", name = "NASCAR Gander Outdoors Truck Series Race at Kentucky", date = "Thursday, Jul 11 7:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4897, track = "Pocono Raceway", name = "Gander RV 150", date = "Saturday, Jul 27 1:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4898, track = "Eldora Speedway", name = "Eldora Dirt Derby", date = "Thursday, Aug 1 9:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4899, track = "Michigan International Speedway", name = "Corrigan Oil 200", date = "Saturday, Aug 10 1:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4900, track = "Bristol Motor Speedway", name = "*NASCAR Gander Outdoors Truck Series Race at Bristol", date = "Thursday, Aug 15 8:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4901, track = "Canadian Tire Motorsport Park", name = "*Chevrolet Silverado 250", date = "Sunday, Aug 25 2:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4902, track = "Las Vegas Motor Speedway", name = "*World of Westgate 200", date = "Friday, Sep 13 9:00:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4903, track = "Talladega Superspeedway", name = "*Sugarlands Shine 250", date = "Saturday, Oct 12 1:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4904, track = "Martinsville Speedway", name = "*NASCAR Gander Outdoors Truck Series Race at Martinsville", date = "Saturday, Oct 26 1:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4905, track = "ISM Raceway", name = "*Lucas Oil 150", date = "Friday, Nov 8 8:30:00 PM" });
            events.Add(new ScheduledEvent() { series = 3, id = 4906, track = "Homestead-Miami Speedway", name = "*Ford EcoBoost 200", date = "Friday, Nov 15 8:00:00 PM" });

            return events;
        }

        public List<ScheduledEvent> BuildFullSchedule()
        {
            var events = new List<ScheduledEvent>();

            events.AddRange(BuildCupSchedule());
            events.AddRange(BuildXFinitySchedule());
            events.AddRange(BuildTruckSchedule());

            return events;
        }
    }
}
