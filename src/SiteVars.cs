// This file is part of the Land Use extension for LANDIS-II.
// For copyright and licensing information, see the NOTICE and LICENSE
// files in this project's top-level directory, and at:
//   https://github.com/LANDIS-II-Foundation/Extension-Land-Use-Change

using Landis.Core;
using Landis.SpatialModeling;

namespace Landis.Extension.LandUse
{
    public class SiteVars
    {
        private static ISiteVar<LandUse> landUse;
        private static AllowHarvestSiteVar allowHarvest;
        //private static AllowEstablishmentSitVar allowEstablishment;

        //---------------------------------------------------------------------

        public static void Initialize(ICore modelCore)
        {
            landUse = modelCore.Landscape.NewSiteVar<LandUse>();
            allowHarvest = new AllowHarvestSiteVar();
            Model.Core.RegisterSiteVar(allowHarvest, "LandUse.AllowHarvest");

            //allowEstablishment = new AllowEstablishmentSiteVar();
            //Model.Core.RegisterSiteVar(allowEstablishment, "LandUse.AllowEstablishment");
            //JSF - What does this do
            //Landis.Library.DensityHarvest.SiteVars.CohortsPartiallyDamaged = modelCore.Landscape.NewSiteVar<int>();
            Landis.Library.BiomassHarvest.SiteVars.CohortsPartiallyDamaged = modelCore.Landscape.NewSiteVar<int>();
        }

        //---------------------------------------------------------------------

        public static ISiteVar<LandUse> LandUse
        {
            get {
                return landUse;
            }
        }
    }
}
