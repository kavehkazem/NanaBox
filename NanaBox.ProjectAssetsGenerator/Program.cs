﻿using ImageMagick;
using Mile.Project.Helpers;
using System.Collections.Concurrent;

namespace NanaBox.ProjectAssetsGenerator
{
    internal class Program
    {
        private static string RepositoryRoot = GitRepository.GetRootPath();

        public static string RepositoryRoot1 { get => RepositoryRoot; set => RepositoryRoot = value; }

        static void Main(string[] args)
        {
            {
                string SourcePath = RepositoryRoot + @"\Assets\OriginalAssets\NanaBox";

                string OutputPath = RepositoryRoot + @"\Assets\PackageAssets";

                ConcurrentDictionary<int, MagickImage> StandardSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastBlackSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastWhiteSources =
                    new ConcurrentDictionary<int, MagickImage>();

                ConcurrentDictionary<int, MagickImage> ConfigurationFileSources =
                    new ConcurrentDictionary<int, MagickImage>();

                foreach (var AssetSize in ProjectAssetsUtilities.AssetSizes)
                {
                    StandardSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "Standard",
                        AssetSize));
                    ContrastBlackSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ContrastBlack",
                        AssetSize));
                    ContrastWhiteSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ContrastWhite",
                        AssetSize));

                    ConfigurationFileSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ConfigurationFile",
                        AssetSize));
                }

                ProjectAssetsUtilities.GeneratePackageApplicationImageAssets(
                    StandardSources,
                    ContrastBlackSources,
                    ContrastWhiteSources,
                    OutputPath);

                ProjectAssetsUtilities.GeneratePackageFileAssociationImageAssets(
                    ConfigurationFileSources,
                    OutputPath,
                    @"ConfigurationFile");

                ProjectAssetsUtilities.GenerateIconFile(
                    StandardSources,
                    OutputPath + @"\..\NanaBox.ico");

                StandardSources[64].Write(
                    OutputPath + @"\..\NanaBox.png");
            }

            {
                string SourcePath = RepositoryRoot + @"\Assets\OriginalAssets\NanaBoxPreview";

                string OutputPath = RepositoryRoot + @"\Assets\PreviewPackageAssets";

                ConcurrentDictionary<int, MagickImage> StandardSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastBlackSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastWhiteSources =
                    new ConcurrentDictionary<int, MagickImage>();

                ConcurrentDictionary<int, MagickImage> ConfigurationFileSources =
                    new ConcurrentDictionary<int, MagickImage>();

                foreach (var AssetSize in ProjectAssetsUtilities.AssetSizes)
                {
                    StandardSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "Standard",
                        AssetSize));
                    ContrastBlackSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ContrastBlack",
                        AssetSize));
                    ContrastWhiteSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ContrastWhite",
                        AssetSize));

                    ConfigurationFileSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ConfigurationFile",
                        AssetSize));
                }

                ProjectAssetsUtilities.GeneratePackageApplicationImageAssets(
                    StandardSources,
                    ContrastBlackSources,
                    ContrastWhiteSources,
                    OutputPath);

                ProjectAssetsUtilities.GeneratePackageFileAssociationImageAssets(
                    ConfigurationFileSources,
                    OutputPath,
                    @"ConfigurationFile");

                ProjectAssetsUtilities.GenerateIconFile(
                    StandardSources,
                    OutputPath + @"\..\NanaBoxPreview.ico");

                StandardSources[64].Write(
                    OutputPath + @"\..\NanaBoxPreview.png");
            }

            Console.WriteLine(
                "NanaBox.ProjectAssetsGenerator task has been completed.");
            Console.ReadKey();
        }
    }
}
