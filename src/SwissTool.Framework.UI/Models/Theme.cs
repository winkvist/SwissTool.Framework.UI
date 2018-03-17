// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Theme.cs" company="Fredrik Winkvist">
//   Copyright (c) Fredrik Winkvist. All rights reserved.
// </copyright>
// <summary>
//   Defines the Theme type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SwissTool.Framework.UI.Models
{
    using System;

    using Newtonsoft.Json;

    using SwissTool.Framework.UI.Enums;

    /// <summary>
    /// The theme.
    /// </summary>
    public class Theme
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; internal set; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [JsonProperty("version")]
        public Version Version { get; internal set; }

        /// <summary>
        /// Gets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        [JsonProperty("author")]
        public string Author { get; internal set; }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [JsonProperty("url")]
        public string Url { get; internal set; }

        /// <summary>
        /// Gets the UI hint.
        /// </summary>
        /// <value>
        /// The UI hint.
        /// </value>
        [JsonProperty("uiHint")]
        public UiHint UiHint { get; internal set; }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public string Path { get; internal set; }

        /// <summary>
        /// Gets the name of the directory.
        /// </summary>
        /// <value>
        /// The name of the directory.
        /// </value>
        public string DirectoryName { get; internal set; }
    }
}
