// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.NET.Build.Containers;

/// <summary>
/// Abstracts over the concept of a local container runtime of some kind. Currently this is only modeled by Docker,
/// but users have expressed desires for Podman, nerdctl, etc as well so this kind of abstraction makes sense to have.
/// </summary>
public interface ILocalDaemon {

    /// <summary>
    /// Loads an image (presumably from a tarball) into the local container runtime.
    /// </summary>
    public Task Load(Image image, ImageReference sourceReference, ImageReference destinationReference);

    /// <summary>
    /// Checks to see if the local container runtime is available. This is used to give nice errors to the user.
    /// </summary>
    public Task<bool> IsAvailable();
}

public static class KnownDaemonTypes {
    public const string Docker = nameof(Docker);
    public static readonly string[] SupportedLocalDaemonTypes = new [] { Docker };
}