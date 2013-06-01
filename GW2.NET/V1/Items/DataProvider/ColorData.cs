using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Items.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2DotNET.V1.Items.DataProvider
{
    public class ColorData : IEnumerable<GwColor>
    {
        private Dictionary<int, GwColor> colorDictionary = new Dictionary<int,GwColor>();

        public ColorData()
        {
            var response = ApiCall.GetContent<Dictionary<string, Dictionary<int, GwColor>>>(
                "colors.json", null, ApiCall.Categories.Miscellaneous)["colors"];
            foreach (var keyvaluepair in response)
            {
                GwColor colorWithId = new GwColor()
                {
                    Id = keyvaluepair.Key,
                    Cloth = keyvaluepair.Value.Cloth,
                    Default = keyvaluepair.Value.Default,
                    Leather = keyvaluepair.Value.Leather,
                    Metal = keyvaluepair.Value.Metal
                };

                colorDictionary.Add(colorWithId.Id, colorWithId);
            }
        }

        public GwColor this[int id]
        {
            get
            {
                return this.colorDictionary[id];
            }
        }

        public IEnumerator<GwColor> GetEnumerator()
        {
            return this.colorDictionary.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.colorDictionary.Values.GetEnumerator();
        }
    }
}
