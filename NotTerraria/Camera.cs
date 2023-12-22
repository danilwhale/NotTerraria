using Microsoft.Xna.Framework;

namespace NotTerraria;

public class Camera
{
    public Vector2 Position;
    public float Zoom;
    public float Rotation;

    public Camera(Vector2 position, float zoom, float rotation)
    {
        Position = position;
        Zoom = zoom;
        Rotation = rotation;
    }

    public Matrix CreateTransform()
    {
        Matrix translate = Matrix.CreateTranslation(new Vector3(Position, 0));
        Matrix rotate = Matrix.CreateRotationZ(MathHelper.ToRadians(Rotation));
        Matrix scale = Matrix.CreateScale(Zoom);

        return translate * rotate * scale;
    }
}