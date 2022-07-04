using System.Collections;
using UnityEngine;

namespace FiftyTifty.Tilemaps
{
    //Index list for the Colours array, which contains the RGB values
    public enum TilemapColourIDs : byte
    {

        Black = 0,
        Red = 1,
        Green = 2,
        Blue = 3,
        White = 4

    }

    //Index list for all the tile's properties
    public enum TileFlags : byte
	{

        IsAccessible = 0,
        IsLand = 1,
        IsWater = 2,
        IsInterior = 3,
        IsNaturalInterior = 4,
        IsHostile = 5,
        IsActivator = 6, 
        IsStair = 7,
        IsPortal = 8,
        HasEffect = 9,
        IsOwned = 10,
        IsOwnedByPlayer = 11,
        IsOwnedByNPC = 12,
        IsOwnedByFaction= 13,
        IsNoPlayerAllowed = 14,
        IsNoNPCAllowed = 15

    }

    //Index list for directions that are allowed from the tile
    public enum TileMovementFlags : byte
	{
        PassableN = 0,
        PassableNE = 1,
        PassableE = 2,
        PassableSE = 3,
        PassableS = 4,
        PassableSW = 5,
        PassableW = 6,
        PassableNW = 7

    }

    public struct Palette
    {

        public static Vector3Int[] Colours = new Vector3Int[]
        {
            //Placeholder colours, final version will have 255 colours
            new Vector3Int(0, 0, 0), //Black
            new Vector3Int(255, 0, 0), //Red
            new Vector3Int(0, 255, 0), //Green
            new Vector3Int(0, 0, 255), //Blue
            new Vector3Int(255, 255, 255) //White

        };

	}

    public class Tile
	{

        public Vector2Int Index //Add the tile's index as a property, to directly find it in the array
		{
            get; private set;
		}

        public byte[] TrianglePaletteIndexes //Each tile is a quad with 2 triangles, each have their own colour from the palette
		{
            get; set;
		}

        private byte[] bytearrayFlags = new byte[2]; //Create the bytes which will be used for bitmask flags
        private byte byteFlagsMovement = 0; //Same for the movement flags

        public BitArray Flags //The bitmask flags for the tile's properties
		{
            get; set;
		}

        public BitArray FlagsMovement
		{
            get; set;
		}

        public Tile(int iX, int iY)
		{

            this.Index = new Vector2Int(iX, iY); //Assign the coords to the tile
            this.Flags = new BitArray(this.bytearrayFlags); //Assign the bitmask flags to the bytes that hold them
            this.FlagsMovement = new BitArray(this.byteFlagsMovement); //Assign the bitmask movement flags to the containing byte

            this.TrianglePaletteIndexes = new byte[2];
            this.TrianglePaletteIndexes[1] = (byte) TilemapColourIDs.Black; //Set the default palette indexes
            this.TrianglePaletteIndexes[2] = (byte) TilemapColourIDs.Black;

        }

	}

    public class Tilemap
    {

        public Vector2Int GridSize
        {
            get;
            private set;
        }
        public uint[,] TileCoords
        {
            get;
            private set;
        }

        public Tile[,] Tiles
        {
            get;
            set;
        }

        public Tilemap[] SubTilemaps
		{
            get; set;
		}

        public byte LayerIndex
		{
			get; set;
        }

        public bool IsWorld
		{
            get; private set;
		}

        public Tilemap(bool bIsWorld, int inGridSizeX, int inGridSizeY, byte inLayerIndex)
		{

            this.GridSize = new Vector2Int (inGridSizeX, inGridSizeY);
            this.TileCoords = new uint[inGridSizeX, inGridSizeY];
            this.Tiles = new Tile[inGridSizeX, inGridSizeY];
            
            this.LayerIndex = inLayerIndex;

            this.IsWorld = bIsWorld;

            for (int iCounterX = 0; iCounterX < inGridSizeX; iCounterX++)
			{

                for (int iCounterY = 0; iCounterY < inGridSizeY; iCounterY++)
				{

                    Tile tileCurrent = new Tile(iCounterX, iCounterY);

                    tileCurrent.Flags[(byte) TileFlags.IsLand] = true;

                    tileCurrent.FlagsMovement[(byte)TileMovementFlags.PassableN] = (iCounterY < inGridSizeY);
                    tileCurrent.FlagsMovement[(byte)TileMovementFlags.PassableNE] = (iCounterY < inGridSizeY & iCounterX < inGridSizeX);
                    tileCurrent.FlagsMovement[(byte)TileMovementFlags.PassableE] = (iCounterX < inGridSizeX);
                    tileCurrent.FlagsMovement[(byte)TileMovementFlags.PassableSE] = (iCounterY > 0 & iCounterX < inGridSizeX);
                    tileCurrent.FlagsMovement[(byte)TileMovementFlags.PassableS] = (iCounterY > 0);
                    tileCurrent.FlagsMovement[(byte)TileMovementFlags.PassableSW] = (iCounterY > 0 & iCounterX > 0);
                    tileCurrent.FlagsMovement[(byte)TileMovementFlags.PassableW] = (iCounterX > 0);
                    tileCurrent.FlagsMovement[(byte)TileMovementFlags.PassableNW] = (iCounterY < inGridSizeY & iCounterX > 0);

                    this.Tiles[iCounterX, iCounterY] = tileCurrent;

                }

			}

		}

    }
}
