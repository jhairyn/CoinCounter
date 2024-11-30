using OpenCvSharp; // For OpenCVSharp functionality
using OpenCvSharp.Extensions; // To handle conversions between Mat and Bitmap
using System;
using System.Windows.Forms;

namespace CoinCounter
{
    public partial class Form1 : Form
    {
        private Mat loadedImage; // Holds the uploaded original image
        private Mat grayscaleImage; // Holds the grayscale version of the image

        public Form1()
        {
            InitializeComponent();
        }

        // Event handler for the Upload Image button
        private void uploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                fileDialog.Title = "Choose an Image";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Load the selected image into an OpenCV Mat
                    loadedImage = Cv2.ImRead(fileDialog.FileName);

                    // Convert the image to grayscale
                    grayscaleImage = new Mat();
                    Cv2.CvtColor(loadedImage, grayscaleImage, ColorConversionCodes.BGR2GRAY);

                    // Display the grayscale image in the PictureBox
                    pictureBox.Image = BitmapConverter.ToBitmap(grayscaleImage);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        // Event handler for the Process Image button
        private void processImage_Click(object sender, EventArgs e)
        {
            if (grayscaleImage == null)
            {
                MessageBox.Show("Please upload an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 1: Apply Gaussian Blur to the grayscale image
            Mat blurredImage = new Mat();
            Cv2.GaussianBlur(grayscaleImage, blurredImage, new OpenCvSharp.Size(15, 15), 0);

            // Step 2: Detect circles using Hough Circle Transform
            CircleSegment[] detectedCircles = Cv2.HoughCircles(
                blurredImage,
                HoughModes.Gradient,
                dp: 1.2,
                minDist: 30,
                param1: 200,
                param2: 30,
                minRadius: 5,
                maxRadius: 50
            );

            if (detectedCircles.Length == 0)
            {
                MessageBox.Show("No coins detected in the image.", "No Coins", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Step 3: Define mapping of coin radius to value
            var coinMapping = new[]
            {
              //  new { Radius = 25, Value = 0.05 },
                //new { Radius = 30, Value = 0.10 },
                //new { Radius = 35, Value = 0.25 },
                //new { Radius = 42, Value = 1.00 },
                //new { Radius = 50, Value = 5.00 },
                //new { Radius = 60, Value = 10.00 },
               // new { Radius = 80, Value = 20.00 },


                new { RadiusRange = (min: 20, max: 28), Value = 0.05 },
                new { RadiusRange = (min: 29, max: 34), Value = 0.10 },
                new { RadiusRange = (min: 35, max: 40), Value = 0.25 },
                new { RadiusRange = (min: 41, max: 47), Value = 1.00 },
                new { RadiusRange = (min: 48, max: 55), Value = 5.00 },
                new { RadiusRange = (min: 46, max: 60), Value = 10.00 },
                new { RadiusRange = (min: 61, max: 70), Value = 20.00 }

            };

            double totalCoinValue = 0.0;

            // Step 4: Analyze detected circles
            foreach (var circle in detectedCircles)
            {
                var center = new OpenCvSharp.Point((int)circle.Center.X, (int)circle.Center.Y);
                int radius = (int)circle.Radius;

                // Determine coin value based on radius
                double? detectedValue = null;
                foreach (var coin in coinMapping)
                {
                    if (Math.Abs(radius - coin.Radius) <= 5) // Tolerance of ±5 pixels
                    {
                        detectedValue = coin.Value;
                        break;
                    }
                }

                if (detectedValue.HasValue)
                {
                    totalCoinValue += detectedValue.Value;

                    // Highlight the detected coin
                    HighlightCoin(loadedImage, center, radius, detectedValue.Value);
                }
            }

            // Step 5: Update display and show results
            pictureBox.Image = BitmapConverter.ToBitmap(loadedImage);
            MessageBox.Show($"Total Coin Value: P{totalCoinValue:F2}", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Helper method to annotate detected coins
        private void HighlightCoin(Mat image, OpenCvSharp.Point center, int radius, double value)
        {
            // Draw a green circle around the coin
            Cv2.Circle(image, center, radius, Scalar.Green, thickness: 5);

            // Add text label for coin value
            Cv2.PutText(
                image,
                $"P{value:F2}",
                new OpenCvSharp.Point(center.X - 10, center.Y - 10),
                HersheyFonts.HersheySimplex,
                fontScale: 1.0,
                color: Scalar.Red,
                thickness: 2
            );
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Placeholder for label click event logic (if needed)
        }
    }
}
