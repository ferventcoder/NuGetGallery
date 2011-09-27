using System.Net.Mail;

namespace NuGetGallery {
    public interface IConfiguration {
        bool ConfirmEmailAddresses { get; }
        string PackageFileDirectory { get; }
        MailAddress GalleryOwnerEmailAddress { get; }
        bool UseAwsSimpleStorageService { get; }
        string S3Bucket { get; }
        string S3AccessKey { get; }
        string S3SecretKey { get; }
    }
}