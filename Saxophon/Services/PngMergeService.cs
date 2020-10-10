using Saxophon.Models;
using Saxophon.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Saxophon.Services
{
    public class PngMergeService
    {
        public void CreateSaxophonePng(ObservableCollection<NoteViewModel> notes, string _fileName)
        {
            BitmapFrame frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/SaxophonLeer.png"),
                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();

            int imageWidth = frame.PixelWidth;
            int imageHeight = frame.PixelHeight;

            int count = 0;

            int countRows = 4;
            int countColumns = 10;

            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                for (int i = 0; i < countRows; i++)
                {
                    for (int j = 0; j < countColumns; j++)
                    {
                        if (notes.Count <= count)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/SaxophonLeer.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.c1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/c1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.cis1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/cis1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.d1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/d1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.dis1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/dis1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.e1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/e1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.f1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/f1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.fis1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/fis1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.g1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/g1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.gis1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/gis1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.a1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/a1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.b1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/b1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.h1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/h1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.c2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/c2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.cis2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/cis2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.d2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/d2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.dis2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/dis2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.e2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/e2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.f2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/f2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.fis2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/fis2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.g2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/g2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.gis2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/gis2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.a2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/a2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.b2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/b2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.h2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/h2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.c3)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/c3.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Saxophone/SaxophonLeer.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }

                        drawingContext.DrawImage(frame, new Rect(imageWidth * j, imageHeight * i, imageWidth, imageHeight));
                        count++;
                    }
                }
            }

            RenderTargetBitmap targetBitmap = new RenderTargetBitmap(imageWidth * countColumns, imageHeight * countRows, 96, 96, PixelFormats.Pbgra32);
            targetBitmap.Render(drawingVisual);

            PngBitmapEncoder bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(targetBitmap));

            using (Stream stream = File.Create(_fileName))
            {
                bitmapEncoder.Save(stream);
            }
        }

        public void CreateFlutePng(ObservableCollection<NoteViewModel> notes, string _fileName)
        {
            BitmapFrame frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/Template.png"),
                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();

            int imageWidth = frame.PixelWidth;
            int imageHeight = frame.PixelHeight;

            int count = 0;
            int columnOneCount = 0;
            int columnTwoCount = 15;
            int columnThreeCount = 30;

            int countRows = 0;
            int countColumns = 0;

            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                while (count < 15)
                {
                    countColumns = 0;
                    frame = CreateFluteFrame(columnOneCount, frame, notes);
                    drawingContext.DrawImage(frame, new Rect(imageWidth * countColumns, imageHeight * countRows, imageWidth, imageHeight));
                    countColumns++;
                    columnOneCount++;
                    frame = CreateFluteFrame(columnTwoCount, frame, notes);
                    drawingContext.DrawImage(frame, new Rect(imageWidth * countColumns, imageHeight * countRows, imageWidth, imageHeight));
                    countColumns++;
                    columnTwoCount++;
                    frame = CreateFluteFrame(columnThreeCount, frame, notes);
                    drawingContext.DrawImage(frame, new Rect(imageWidth * countColumns, imageHeight * countRows, imageWidth, imageHeight));
                    countRows++;
                    columnThreeCount++;
                    count++;
                }
            }

            RenderTargetBitmap targetBitmap = new RenderTargetBitmap(imageWidth * 3, imageHeight * 15, 96, 96, PixelFormats.Pbgra32);
            targetBitmap.Render(drawingVisual);

            PngBitmapEncoder bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(targetBitmap));

            using (Stream stream = File.Create(_fileName))
            {
                bitmapEncoder.Save(stream);
            }
        }

        private BitmapFrame CreateFluteFrame(int count, BitmapFrame frame, ObservableCollection<NoteViewModel> notes)
        {
            if (count >= notes.Count)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/Template.png"),
                       BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.d1)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/d1.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.dis1)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/dis1.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.es1)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/es1.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.e1)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/e1.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.f1)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/f1.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.fis1)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/fis1.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.ges1)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/ges1.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.g1)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/g1.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.gis1)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/gis1.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.as1)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/as1.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.a1)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/a1.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.ais1)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/ais1.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.b1)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/b1.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.h1)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/h1.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.c2)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/c2.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.d2)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/d2.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.dis2)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/dis2.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.es2)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/es2.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.e2)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/e2.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.f2)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/f2.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.fis2)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/fis2.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.ges2)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/ges2.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.g2)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/g2.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.gis2)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/gis2.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.as2)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/as2.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.a2)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/a2.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.ais2)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/ais2.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.b2)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/b2.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.h2)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/h2.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else if (notes[count].Note == Note.c3)
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/c3.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            else
            {
                frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Querfloete/Template.png"),
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            }
            return frame;
        }
        public void CreateBagpipesPng(ObservableCollection<NoteViewModel> notes, string _fileName)
        {
            BitmapFrame frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Dudelsack/Template.png"),
                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();

            int imageWidth = frame.PixelWidth;
            int imageHeight = frame.PixelHeight;

            int count = 0;

            int countRows = 4;
            int countColumns = 10;

            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                for (int i = 0; i < countRows; i++)
                {
                    for (int j = 0; j < countColumns; j++)
                    {
                        if (notes.Count <= count)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Dudelsack/Template.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.a1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Dudelsack/a1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.a2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Dudelsack/a2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.c2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Dudelsack/c2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.d2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Dudelsack/d2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.e2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Dudelsack/e2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.f2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Dudelsack/f2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.g1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Dudelsack/g1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.g2)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Dudelsack/g2.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else if (notes[count].Note == Note.h1)
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Dudelsack/h1.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }
                        else
                        {
                            frame = BitmapDecoder.Create(new Uri("pack://application:,,,/Saxophon;component/Resources/Dudelsack/Template.png"),
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                        }

                        drawingContext.DrawImage(frame, new Rect(imageWidth * j, imageHeight * i, imageWidth, imageHeight));
                        count++;
                    }
                }
            }

            RenderTargetBitmap targetBitmap = new RenderTargetBitmap(imageWidth * countColumns, imageHeight * countRows, 96, 96, PixelFormats.Pbgra32);
            targetBitmap.Render(drawingVisual);

            PngBitmapEncoder bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(targetBitmap));

            using (Stream stream = File.Create(_fileName))
            {
                bitmapEncoder.Save(stream);
            }
        }
    }
}
