﻿using Content.Shared.Chemistry.Components;

namespace Content.Server.Atmos.Components
{
    [RegisterComponent]
    public sealed class GasMixtureHolderComponent : Component, IGasMixtureHolder
    {
        [DataField("air")] public GasMixture Air { get; set; } = new GasMixture();

        [ViewVariables] public Solution Liquids { get; set; } = new();
    }
}
