using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
using System.Web;

namespace NuGetGallery {
    public class Configuration : IConfiguration {
        static readonly Dictionary<string, Lazy<object>> configThunks = new Dictionary<string, Lazy<object>>();

        public static string ReadAppSetting(string key) {
            var appSettingKey = "NuGetGallery:" + key;
            var configValue = ConfigurationManager.AppSettings[appSettingKey];
            return configValue;
        }

        public static T ReadConfiguration<T>(
            string key,
            Func<string, T> thunk) {
            if (!configThunks.ContainsKey(key))
                configThunks.Add(key, new Lazy<object>(() => {
                    var value = ReadAppSetting(key);
                    return thunk(value);
                }));

            return (T)configThunks[key].Value;
        }

        public bool ConfirmEmailAddresses {
            get {
                return ReadConfiguration<bool>(
                    "ConfirmEmailAddresses",
                    (value) => bool.Parse(value ?? bool.TrueString));
            }
        }

        public string PackageFileDirectory {
            get {
                return ReadConfiguration<string>(
                    "PackageFileDirectory",
                    (value) => value ?? HttpContext.Current.Server.MapPath("~/App_Data/Packages"));
            }
        }

        public MailAddress GalleryOwnerEmailAddress {
            get {
                return ReadConfiguration<MailAddress>(
                    "GalleryOwnerEmail",
                    (value) => new MailAddress(value));
            }
        }

        public bool UseAwsSimpleStorageService {
            get {
                return ReadConfiguration<bool>(
                   "UseAwsSimpleStorageService",
                   (value) => bool.Parse(value ?? bool.FalseString));
            }
        }

        public string S3Bucket {
            get {
                return ReadConfiguration<string>(
                   "S3Bucket",
                   (value) => value ?? string.Empty);
            }
        }

        public string S3AccessKey {
            get {
                return ReadConfiguration<string>(
                   "S3AccessKey",
                   (value) => value ?? string.Empty);
            }
        }

        public string S3SecretKey {
            get {
                return ReadConfiguration<string>(
                  "S3SecretKey",
                  (value) => value ?? string.Empty);
            }
        }
    }
}