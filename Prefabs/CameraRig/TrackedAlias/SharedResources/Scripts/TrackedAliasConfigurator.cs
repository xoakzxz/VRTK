namespace VRTK.Prefabs.CameraRig.TrackedAlias
{
    using UnityEngine;
    using Malimbe.XmlDocumentationAttribute;
    using Malimbe.PropertySerializationAttribute;
    using Zinnia.Data.Type;
    using Zinnia.Data.Attribute;
    using Zinnia.Tracking.Follow;
    using Zinnia.Tracking.Velocity;
    using Zinnia.Rule;

    /// <summary>
    /// Sets up the Tracked Alias Prefab based on the provided user settings.
    /// </summary>
    public class TrackedAliasConfigurator : MonoBehaviour
    {
        #region Facade Settings
        /// <summary>
        /// The public facade.
        /// </summary>
        [Serialized]
        [field: Header("Facade Settings"), DocumentedByXml, Restricted]
        public TrackedAliasFacade Facade { get; protected set; }
        #endregion

        #region Object Follow Settings
        /// <summary>
        /// The <see cref="ObjectFollower"/> component for the PlayArea.
        /// </summary>
        [Serialized]
        [field: Header("Object Follow Settings"), DocumentedByXml, Restricted]
        public ObjectFollower PlayArea { get; protected set; }

        /// <summary>
        /// The <see cref="ObjectFollower"/> component for the Headset.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ObjectFollower Headset { get; protected set; }

        /// <summary>
        /// The <see cref="ObjectFollower"/> component for the Left Controller.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ObjectFollower LeftController { get; protected set; }

        /// <summary>
        /// The <see cref="ObjectFollower"/> component for the Right Controller.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ObjectFollower RightController { get; protected set; }
        #endregion

        #region Velocity Tracker Settings
        /// <summary>
        /// The <see cref="VelocityTrackerProcessor"/> component containing the Headset Velocity Trackers.
        /// </summary>
        [Serialized]
        [field: Header("Velocity Tracker Settings"), DocumentedByXml, Restricted]
        public VelocityTrackerProcessor HeadsetVelocityTrackers { get; protected set; }
        /// <summary>
        /// The <see cref="VelocityTrackerProcessor"/> component containing the Left Controller Velocity Trackers.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public VelocityTrackerProcessor LeftControllerVelocityTrackers { get; protected set; }
        /// <summary>
        /// The <see cref="VelocityTrackerProcessor"/> component containing the Right Controller Velocity Trackers.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public VelocityTrackerProcessor RightControllerVelocityTrackers { get; protected set; }
        #endregion

        #region Other Settings
        /// <summary>
        /// The <see cref="ListContainsRule"/> for defining the valid <see cref="Camera"/> collection.
        /// </summary>
        [Serialized]
        [field: Header("Other Settings"), DocumentedByXml, Restricted]
        public ListContainsRule ValidCameras { get; protected set; }
        #endregion

        /// <summary>
        /// Sets up the TrackedAlias prefab with the specified settings.
        /// </summary>
        public virtual void SetUpCameraRigsConfiguration()
        {
            PlayArea.Targets.Clear(false);
            foreach (GameObject target in Facade.PlayAreas)
            {
                PlayArea.Targets.Add(target);
            }

            Headset.Sources.Clear(false);
            foreach (GameObject source in Facade.Headsets)
            {
                Headset.Sources.Add(source);
            }

            ValidCameras.Objects.Clear(false);
            foreach (Camera headsetCamera in Facade.HeadsetCameras)
            {
                ValidCameras.Objects.Add(headsetCamera);
            }

            HeadsetVelocityTrackers.VelocityTrackers.Clear(false);
            foreach (VelocityTracker velocityTracker in Facade.HeadsetVelocityTrackers)
            {
                HeadsetVelocityTrackers.VelocityTrackers.Add(velocityTracker);
            }

            LeftController.Sources.Clear(false);
            foreach (GameObject source in Facade.LeftControllers)
            {
                LeftController.Sources.Add(source);
            }

            RightController.Sources.Clear(false);
            foreach (GameObject source in Facade.RightControllers)
            {
                RightController.Sources.Add(source);
            }

            LeftControllerVelocityTrackers.VelocityTrackers.Clear(false);
            foreach (VelocityTracker velocityTracker in Facade.LeftControllerVelocityTrackers)
            {
                LeftControllerVelocityTrackers.VelocityTrackers.Add(velocityTracker);
            }

            RightControllerVelocityTrackers.VelocityTrackers.Clear(false);
            foreach (VelocityTracker velocityTracker in Facade.RightControllerVelocityTrackers)
            {
                RightControllerVelocityTrackers.VelocityTrackers.Add(velocityTracker);
            }
        }

        /// <summary>
        /// Notifies that the headset has started being tracked.
        /// </summary>
        public virtual void NotifyHeadsetTrackingBegun()
        {
            Facade.HeadsetTrackingBegun?.Invoke();
        }

        /// <summary>
        /// Notifies that the left controller has started being tracked.
        /// </summary>
        public virtual void NotifyLeftControllerTrackingBegun()
        {
            Facade.LeftControllerTrackingBegun?.Invoke();
        }

        /// <summary>
        /// Notifies that the right controller has started being tracked.
        /// </summary>
        public virtual void NotifyRightControllerTrackingBegun()
        {
            Facade.RightControllerTrackingBegun?.Invoke();
        }

        protected virtual void OnEnable()
        {
            SetUpCameraRigsConfiguration();
        }
    }
}