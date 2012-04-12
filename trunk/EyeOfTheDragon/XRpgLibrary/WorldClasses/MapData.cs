using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.WorldClasses
{
    public class MapData
    {
        public string MapName;
        public MapLayerData[] Layers;
        public MovementLayerData MovementLayer;
        public TilesetData[] Tilesets;

        private MapData()
        {
        }

        public MapData(string mapName, List<TilesetData> tilesets, List<MapLayerData> layers, MovementLayerData mLayer)
        {
            MapName = mapName;
            Tilesets = tilesets.ToArray();
            Layers = layers.ToArray();
            MovementLayer = mLayer;
        }
    }
}
