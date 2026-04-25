using OpenCvSharp;

class Program
{
    static void Main()
    {
        var faceCascade = new CascadeClassifier("haarcascade_frontalface_default.xml");

        using var image = Cv2.ImRead("test_image.jpg");

        if (image.Empty())
        {
            Console.WriteLine("Error: Could not find 'test_image.jpg'.");
            Console.WriteLine("Check if the file is in your bin folder!");
            return;
        }

        using var gray = new Mat();
        Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);

        var faces = faceCascade.DetectMultiScale(gray, 1.1, 5, minSize: new Size(30, 30));

        Console.WriteLine($"Detected {faces.Length} faces in the image.");

        foreach (var rect in faces)
        {
            Cv2.Rectangle(image, rect, Scalar.Red, 3);
        }

        Cv2.ImShow("Static Image Detection", image);
        Cv2.WaitKey(0); 
    }
}
