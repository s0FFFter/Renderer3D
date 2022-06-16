﻿using System.Numerics;

namespace Renderer3D.Models.Data
{
    public struct TransformMatrixes
    {
        public readonly Matrix4x4 WorldMatrix;
        public readonly Matrix4x4 ViewMatrix;
        public readonly Matrix4x4 PerspectiveMatrix;
        public readonly Matrix4x4 ViewportMatrix;
        public readonly Matrix4x4 TransformMatrix;

        public TransformMatrixes(Matrix4x4 world, Matrix4x4 view, Matrix4x4 perspective, Matrix4x4 viewport)
        {
            (WorldMatrix, ViewMatrix, PerspectiveMatrix, ViewportMatrix, TransformMatrix) = (world, view, perspective, viewport, world * view * perspective * viewport);
        }
    }
}
