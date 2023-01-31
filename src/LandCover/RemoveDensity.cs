﻿// This file is part of the Land Use extension for LANDIS-II.
// For copyright and licensing information, see the NOTICE and LICENSE
// files in this project's top-level directory, and at:
//   https://github.com/LANDIS-II-Foundation/Extension-Land-Use-Change

using Landis.Library.SiteHarvest;
using Landis.Library.Succession;
using Landis.SpatialModeling;
using log4net;

namespace Landis.Extension.LandUse.LandCover
{
    class RemoveDensity
        : IChange
    {
        public const string TypeName = "RemoveDensity";
        private bool repeat = false;
        private ICohortCutter cohortCutter;
        private Planting.SpeciesList speciesToPlant;
        private static readonly ILog log = LogManager.GetLogger(typeof(RemoveTrees));
        private static readonly bool isDebugEnabled = log.IsDebugEnabled;

        //---------------------------------------------------------------------

        string IChange.Type
        {
            get { return TypeName; }
        }

        //---------------------------------------------------------------------

        bool IChange.Repeat
        {
            get { return repeat; }
        }

        //---------------------------------------------------------------------

        public RemoveDensity(ICohortCutter        cohortCutter,
                           Planting.SpeciesList speciesToPlant,
                            bool repeatHarvest)
        {
            this.cohortCutter = cohortCutter;
            this.speciesToPlant = speciesToPlant;
            this.repeat = repeatHarvest;
        }

        //---------------------------------------------------------------------

        public void ApplyTo(ActiveSite site, bool newLandUse)
        {
            if (newLandUse || (!newLandUse && repeat))
            {
                if (isDebugEnabled)
                    log.DebugFormat("    Applying LCC {0} to site {1}",
                                    GetType().Name,
                                    site.Location);

                // For now, we don't do anything with the counts of cohorts cut.
                CohortCounts cohortCounts = new CohortCounts();
                cohortCutter.Cut(site, cohortCounts);
                if (speciesToPlant != null)
                    Reproduction.ScheduleForPlanting(speciesToPlant, site);
            }
        }

        public void PrintLandCoverDetails()
        {
            Model.Core.UI.WriteLine("Tree parameters not available due to library functionality");
        }
    }
}
