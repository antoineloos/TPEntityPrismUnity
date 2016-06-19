﻿using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrismUnity.Utils
{
   
        public class WrapPanelRegionAdapter : RegionAdapterBase<WrapPanel>
        {
            public WrapPanelRegionAdapter(IRegionBehaviorFactory factory)
                : base(factory)
            {

            }

            protected override void Adapt(IRegion region, WrapPanel regionTarget)
            {
                region.Views.CollectionChanged += (s, e) =>
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach (FrameworkElement element in e.NewItems)
                        {
                            regionTarget.Children.Add(element);
                        }
                    }

                    
                };
            }

            protected override IRegion CreateRegion()
            {
                return new AllActiveRegion();
            }



        }
    
}
