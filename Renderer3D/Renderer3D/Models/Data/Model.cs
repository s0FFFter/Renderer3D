﻿using Renderer3D.Models.Data.Properties;
using System.Collections.Generic;

namespace Renderer3D.Models.Data
{
    public class Model
    {
        public string MaterialKey { get; set; }
        public MaterialProperties MaterialProperties { get; set; }
        public List<PolygonIndex> Polygons { get; } = new List<PolygonIndex>();

        public PolygonValue GetPolygonValue(PolygonIndex p, MeshProperties meshProperties)
        {
            TriangleValue[] indices = new TriangleValue[p.TriangleIndices.Length];
            for (int i = 0; i < p.TriangleIndices.Length; i++)
            {
                indices[i] = GetTriangleValue(p.TriangleIndices[i], meshProperties);
            }

            return new PolygonValue
            {
                TriangleValues = indices
            };
        }

        public TriangleValue GetTriangleValue(TriangleIndex t, MeshProperties meshProperties)
        {
            return new TriangleValue
            {
                v0 = new VertexValue
                {
                    Coordinates = meshProperties.Vertices[t.Vi1.Coordinates],
                    Normal = t.Vi1.Normal != -1 ? meshProperties.Normals[t.Vi1.Normal] : default,
                    Texture = t.Vi1.Texture != -1 ? meshProperties.Textures[t.Vi1.Texture] : default
                },
                v1 = new VertexValue
                {
                    Coordinates = meshProperties.Vertices[t.Vi2.Coordinates],
                    Normal = t.Vi2.Normal != -1 ? meshProperties.Normals[t.Vi2.Normal] : default,
                    Texture = t.Vi2.Texture != -1 ? meshProperties.Textures[t.Vi2.Texture] : default
                },
                v2 = new VertexValue
                {
                    Coordinates = meshProperties.Vertices[t.Vi3.Coordinates],
                    Normal = t.Vi3.Normal != -1 ? meshProperties.Normals[t.Vi3.Normal] : default,
                    Texture = t.Vi3.Texture != -1 ? meshProperties.Textures[t.Vi3.Texture] : default
                }
            };
        }
    }
}
