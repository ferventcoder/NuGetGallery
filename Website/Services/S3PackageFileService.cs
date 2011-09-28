using System;
using System.IO;
using System.Web.Mvc;
using Amazon.S3;
using Amazon.S3.Model;

namespace NuGetGallery {
    class S3PackageFileService : IPackageFileService {

        private readonly IConfiguration configuration;
        private readonly string bucketName = "";
        private readonly string accessKeyId = "";
        private readonly string accessSecret = "";

        public S3PackageFileService(IConfiguration configuration) {
            this.configuration = configuration;
            this.bucketName = configuration.S3Bucket;
            this.accessKeyId = configuration.S3AccessKey;
            this.accessSecret = configuration.S3SecretKey;
        }

        public void SavePackageFile(Package package, Stream packageFile) {
            if (package == null)
                throw new ArgumentNullException("package");
            if (packageFile == null)
                throw new ArgumentNullException("packageFile");
            if (package.PackageRegistration == null || string.IsNullOrWhiteSpace(package.PackageRegistration.Id) || string.IsNullOrWhiteSpace(package.Version))
                throw new ArgumentException("The package is missing required data.", "package");

            var fileName = BuildPackageFileSavePath(package.PackageRegistration.Id, package.Version);
            UploadToAmazonService(packageFile, fileName);
        }

        public ActionResult CreateDownloadPackageResult(Package package) {
            if (package == null)
                throw new ArgumentNullException("package");
            if (package.PackageRegistration == null || string.IsNullOrWhiteSpace(package.PackageRegistration.Id) || string.IsNullOrWhiteSpace(package.Version))
                throw new ArgumentException("The package is missing required data.", "package");

            var fileName = BuildPackageFileSavePath(package.PackageRegistration.Id, package.Version);
            var downloadLink = string.Format("http://{0}.s3.amazonaws.com/{1}",bucketName,fileName);
            var result = new RedirectResult(downloadLink, false);
           
            //var result = new FilePathResult(downloadLink, Const.PackageContentType);
            //result.FileDownloadName = downloadLink;

            return result;
        }

        string BuildPackageFileSavePath(string id, string version) {
            return string.Format(Const.PackageFileSavePathTemplate, id, version, Const.PackageFileExtension);
        }

        private void UploadToAmazonService(Stream packageFile, string fileName) {
            PutObjectRequest request = new PutObjectRequest();
            request.WithBucketName(bucketName);
            request.WithKey(fileName);
            request.WithInputStream(packageFile);
            request.AutoCloseStream = true;
            request.CannedACL = S3CannedACL.PublicRead;
            request.WithTimeout((int)TimeSpan.FromMinutes(30).TotalMilliseconds);
           
            AmazonS3 client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKeyId, accessSecret);
            using (S3Response r = client.PutObject(request)) { }
        }

        public void DeletePackageFile(string id, string version) {
            var fileName = BuildPackageFileSavePath(id, version);

            DeleteObjectRequest request = new DeleteObjectRequest();
            request.WithBucketName(bucketName);
            request.WithKey(fileName);

            AmazonS3 client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKeyId, accessSecret);

           using (S3Response r = client.DeleteObject(request)) { }
        }
    }
}