namespace GifAnimation.Pipeline
{
    using Microsoft.Xna.Framework.Content.Pipeline;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using Microsoft.Xna.Framework.Graphics;

    [ContentImporter(".gif", DisplayName="Gif Animation Importer", DefaultProcessor="Gif Animation Processor")]
    internal class GifAminationImporter : ContentImporter<GifAnimationContent>
    {
        public override GifAnimationContent Import(string filename, ContentImporterContext context)
        {
            GifAnimationContent content = new GifAnimationContent();
            Image source = Image.FromFile(filename);
            FrameDimension dimension = new FrameDimension(source.FrameDimensionsList[0]);
            int frameCount = source.GetFrameCount(dimension);
            content.Frames = new TextureData[frameCount];
            for (int i = 0; i < frameCount; i++)
            {
                source.SelectActiveFrame(dimension, i);
                byte[] buffer = Quantizer.Quantize(source);
                content.Frames[i].__1__SurfaceFormat = SurfaceFormat.Color;
                content.Frames[i].__2__Width = source.Width;
                content.Frames[i].__3__Height = source.Height;
                content.Frames[i].__4__Levels = 1;

                byte[] bgraPixelData = new byte[buffer.Length];
                for (int j = 0; j < buffer.Length; j += 4)
                {
                    bgraPixelData[j] = buffer[j + 2];
                    bgraPixelData[j + 1] = buffer[j + 1];
                    bgraPixelData[j + 2] = buffer[j];
                    bgraPixelData[j + 3] = buffer[j + 3]; //The video comes with 0 alpha so it is transparent
                }

                content.Frames[i].Data = bgraPixelData;
            }
            source.Dispose();
            return content;
        }
    }
}

