using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Leap;
namespace WinFormSample
{
    public partial class FrameDataForm : Form, ILeapEventDelegate
    {
        private Controller controller;
        private LeapEventListener listener;
        //public Frame frame_read = new Frame();
        public FrameDataForm()
        {
            InitializeComponent();
            this.controller = new Controller();
            this.listener = new LeapEventListener(this);
            controller.AddListener(listener);
            this.controller.SetPolicy (Controller.PolicyFlag.POLICY_IMAGES);
        }

        delegate void LeapEventDelegate(string EventName);
        public void LeapEventNotification(string EventName)
        {
            if (!this.InvokeRequired)
            {
                switch (EventName)
                {
                    case "onInit":
                        Debug.WriteLine("Init");
                        break;
                    case "onConnect":
                        this.connectHandler();
                        break;
                    case "onFrame":
                        if(!this.Disposing) 
                            this.newFrameHandler(this.controller.Frame());
                        break;
                }
            }
            else
            {
                BeginInvoke(new LeapEventDelegate(LeapEventNotification), new object[] { EventName });
            }
        }

        void connectHandler()
        {
            this.controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
            this.controller.Config.SetFloat("Gesture.Circle.MinRadius", 40.0f);
            this.controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

        void newFrameHandler(Frame frame)
        {
            //The following are Label controls added in design view for the form
            this.displayID.Text = frame.Id.ToString();
            this.displayTimestamp.Text = frame.Timestamp.ToString();
            this.displayFPS.Text = frame.CurrentFramesPerSecond.ToString();
            this.displayIsValid.Text = frame.IsValid.ToString();
            this.displayGestureCount.Text = frame.Gestures().Count.ToString();
            this.displayImageCount.Text = frame.Images.Count.ToString();
			this.controller.SetPolicy (Controller.PolicyFlag.POLICY_IMAGES);
            frame = controller.Frame();
            Leap.Image image = frame.Images [1];
            //double[] distortion_buffer = image.Distortion;

			/*double horizontal_slope = (double)Math.Tan (160 * 180 / Math.PI);
			double vertical_slope = (double)Math.Tan (50 * 180 / Math.PI);
			Vector pixel = image.Warp (new Vector (horizontal_slope, vertical_slope, 0));
			Vector feature = new Vector (127, 68, 0);
			Vector slopes = image.Rectify (feature);*/
			//int data_index = (int)(Math.Floor (pixel.y) * image.Width + Math.Floor (pixel.x)*image.Height);
			//Console.WriteLine (data_index);
			//display_idx.Text = data_index.ToString();
			//byte brightness = image.Data [data_index];
			const double W = 320, H = 120;
			double destinationWidth = W;
			double destinationHeight = H;
			Bitmap bitmap = new Bitmap (image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
			Bitmap cbitmap = new Bitmap ((int)W, (int)H, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
			label1.Text = "Width : " + image.Width.ToString();
			label2.Text = "Height : " + image.Height.ToString();
			
			//set palette
			ColorPalette grayscale = bitmap.Palette;
			for (int i = 0; i < 256; i++) {
				grayscale.Entries [i] = Color.FromArgb ((int)255, i, i, i);

			}
			bitmap.Palette = grayscale;
			ColorPalette cgrayscale = cbitmap.Palette;
			for (int i = 0; i < 256; i++) {
				cgrayscale.Entries [i] = Color.FromArgb ((int)255, i, i, i);
			}
			cbitmap.Palette = cgrayscale;
			Rectangle lockArea = new Rectangle (0, 0, 100, 100);
			Rectangle clockArea = new Rectangle (0, 0, 100, 100);
			BitmapData bitmapData = bitmap.LockBits (lockArea, ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
			BitmapData cbitmapData = cbitmap.LockBits (clockArea, ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
			byte[] rawImageData = image.Data;
			//System.Runtime.InteropServices.Marshal.Copy (rawImageData, 0, bitmapData.Scan0, image.Width * image.Height);
			//bitmap.UnlockBits (bitmapData);

			
			byte[] destination = new byte[(int)destinationWidth*(int)destinationHeight];
			byte[] destination1 = new byte[(int)destinationWidth*(int)destinationHeight];
			
			

			//define needed variables outside the inner loop
			double calibrationX, calibrationY;
			double weightX, weightY;
			double dX, dX1, dX2, dX3, dX4;
			double dY, dY1, dY2, dY3, dY4;
			int x1, x2, y1, y2;
			//int denormalizedX, denormalizedY;
			
			byte[] raw = image.Data;
			
			float[] distortion_buffer = image.Distortion;

			//Local variables for values needed in loop
			int distortionWidth = image.DistortionWidth;
			int width = image.Width;
			int height = image.Height;

			
			for (int i = 0; i < (int)destinationWidth; i++) {
				for (int j = 0; j < (int)destinationHeight; j++) {
					//Calculate the position in the calibration map (still with a fractional part)
					calibrationX = 63.0f * (double)i/destinationWidth;
					calibrationY = 62.0f * (1.0f - (double)j/destinationHeight); // The y origin is at the bottom
					//Save the fractional part to use as the weight for interpolation
					//weightX = calibrationX - (double)Math.Truncate((double)calibrationX);;
					//weightY = calibrationY - (double)Math.Truncate((double)calibrationY);

					weightX = calibrationX - (double)((int)calibrationX);;
					weightY = calibrationY - (double)((int)calibrationY);
					//Get the x,y coordinates of the closest calibration map points to the target pixel
					//x1 = (int)Math.Truncate((double)calibrationX); //Note truncation to int
					//y1 = (int)Math.Truncate((double)calibrationY);
					x1 = (int)calibrationX; //Note truncation to int
					y1 = (int)calibrationY;
					x2 = x1 + 1;
					y2 = y1 + 1;

					//Look up the x and y values for the 4 calibration map points around the target
					dX1 = distortion_buffer[x1 * 2 + y1 * distortionWidth];
					dX2 = distortion_buffer[x2 * 2 + y1 * distortionWidth];
					dX3 = distortion_buffer[x1 * 2 + y2 * distortionWidth];
					dX4 = distortion_buffer[x2 * 2 + y2 * distortionWidth];
					dY1 = distortion_buffer[x1 * 2 + y1 * distortionWidth + 1];
					dY2 = distortion_buffer[x2 * 2 + y1 * distortionWidth + 1];
					dY3 = distortion_buffer[x1 * 2 + y2 * distortionWidth + 1];
					dY4 = distortion_buffer[x2 * 2 + y2 * distortionWidth + 1];

					//Bilinear interpolation of the looked-up values:
					// X value
					dX = dX1 * (1 - weightX) * (1 - weightY) +
							dX2 * weightX * (1 - weightY) +
							dX3 * (1 - weightX) * weightY +
							dX4 * weightX * weightY;

					// Y value
					dY = dY1 * (1 - weightX) * (1 - weightY) +
							dY2 * weightX * (1 - weightY) +
							dY3 * (1 - weightX) * weightY +
							dY4 * weightX * weightY;

					// Reject points outside the range [0..1]
					if((dX >= 0) && (dX <= 1) && (dY >= 0) && (dY <= 1)) {
						//Denormalize from [0..1] to [0..width] or [0..height]
						//denormalizedX = (int)Math.Truncate((double)(dX * width));
						//denormalizedY = (int)Math.Truncate((double)(dY * height));

						//look up the brightness value for the target pixel
						destination[i+(int)(destinationWidth*j)] = raw[(int)((dX * width) + (int)(dY * height) * width)];
						//destination[j+(int)destinationHeight*i] = raw[denormalizedX + denormalizedY * width];
						//Console.Write("1");
					} else {
						destination[i+(int)(destinationWidth*j)] = 1;
						
						//Console.Write("0");
						//destination[j+(int)destinationHeight*i] = 0;/
					}
					destination1[i+(int)(destinationWidth*j)] = raw[(i*2)+(j*width*2)];
					//destination[i+(int)(destinationWidth*j)] = 255;
				}
			}
			
			System.Runtime.InteropServices.Marshal.Copy (destination, 0, cbitmapData.Scan0, (int)destinationWidth*(int)destinationHeight);
			//System.Runtime.InteropServices.Marshal.Copy (rawImageData, 0, bitmapData.Scan0, (int)image.Height*(int)image.Width);
			cbitmap.UnlockBits (cbitmapData);
			
			pictureBox1.Image = cbitmap;

			Leap.Image image1 = frame.Images [1];
			Bitmap bitmap1 = new Bitmap ((int)W, (int)H, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
			//set palette
			ColorPalette grayscale1 = bitmap1.Palette;
			for (int i = 0; i < 256; i++) {
				grayscale1.Entries [i] = Color.FromArgb ((int)255, i, i, i);
			}
			
			bitmap1.Palette = grayscale1;
			Rectangle lockArea1 = new Rectangle (0, 0, 100, 100);
			BitmapData bitmapData1 = bitmap1.LockBits (lockArea, ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
			byte[] rawImageData1 = image1.Data;
			System.Runtime.InteropServices.Marshal.Copy (destination1, 0, bitmapData1.Scan0, (int)destinationWidth*(int)destinationHeight);
			bitmap1.UnlockBits (bitmapData1);
			pictureBox2.Image = bitmap1;
			
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (components != null)
                    {
                        components.Dispose();
                    }
                    this.controller.RemoveListener(this.listener);
                    this.controller.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private void FrameDataForm_Load(object sender, EventArgs e)
        {

        }
    }

    public interface ILeapEventDelegate
    {
        void LeapEventNotification(string EventName);
    }

    public class LeapEventListener : Listener
    {
        ILeapEventDelegate eventDelegate;

        public LeapEventListener(ILeapEventDelegate delegateObject)
        {
            this.eventDelegate = delegateObject;
        }
        public override void OnInit(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onInit");
        }
        public override void OnConnect(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onConnect");
        }
        public override void OnFrame(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onFrame");
        }
        public override void OnExit(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onExit");
        }
        public override void OnDisconnect(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onDisconnect");
        }
    }
}