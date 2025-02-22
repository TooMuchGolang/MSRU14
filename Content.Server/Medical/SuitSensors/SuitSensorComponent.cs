using Content.Shared.Medical.SuitSensor;

namespace Content.Server.Medical.SuitSensors
{
    /// <summary>
    ///     Tracking device, embedded in almost all uniforms and jumpsuits.
    ///     If enabled, will report to crew monitoring console owners position and status.
    /// </summary>
    [RegisterComponent]
    [Access(typeof(SuitSensorSystem))]
    public sealed class SuitSensorComponent : Component
    {
        /// <summary>
        ///     Choose a random sensor mode when item is spawned.
        /// </summary>
        [DataField("randomMode")]
        public bool RandomMode = false;

        /// <summary>
        ///     If true user can't change suit sensor mode
        /// </summary>
        [DataField("controlsLocked")]
        public bool ControlsLocked = false;

        /// <summary>
        ///     Current sensor mode. Can be switched by user verbs.
        /// </summary>
        [DataField("mode")]
        public SuitSensorMode Mode = SuitSensorMode.SensorCords;

        /// <summary>
        ///     Activate sensor if user wear it in this slot.
        /// </summary>
        [DataField("activationSlot")]
        public string ActivationSlot = "jumpsuit";

        /// <summary>
        /// Activate sensor if user has this in a sensor-compatible container.
        /// </summary>
        [DataField("activationContainer")]
        public string? ActivationContainer;

        /// <summary>
        ///     How often does sensor update its owners status (in seconds). Limited by the system update rate.
        /// </summary>
        [DataField("updateRate")]
        public TimeSpan UpdateRate = TimeSpan.FromSeconds(2f);

        /// <summary>
        ///     Current user that wears suit sensor. Null if nobody wearing it.
        /// </summary>
        [ViewVariables]
        public EntityUid? User = null;

        /// <summary>
        ///     Last time when sensor updated owners status
        /// </summary>
        public TimeSpan LastUpdate = TimeSpan.Zero;

        /// <summary>
        ///     The station this suit sensor belongs to. If it's null the suit didn't spawn on a station and the sensor doesn't work.
        /// </summary>
        [DataField("station")]
        public EntityUid? StationId = null;

        /// <summary>
        ///     The server the suit sensor sends it state to.
        ///     The suit sensor will try connecting to a new server when no server is connected.
        ///     It does this by calling the servers entity system for performance reasons.
        /// </summary>
        [DataField("server")]
        public string? ConnectedServer = null;
    }
}
