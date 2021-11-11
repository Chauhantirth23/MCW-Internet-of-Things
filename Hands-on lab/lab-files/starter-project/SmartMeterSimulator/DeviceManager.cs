using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Provisioning.Client;
using Microsoft.Azure.Devices.Provisioning.Client.Transport;
using Microsoft.Azure.Devices.Shared;

namespace SmartMeterSimulator
{
    class DeviceManager
    {
        /// <summary>
        /// Register a single device with the device provisioning service.
        /// </summary>
        /// <param name="enrollmentKey">Group Enrollment Key</param>
        /// <param name="idScope">DPS Service ID Scope</param>
        /// <param name="deviceId">Device Id of the device being registered</param>
        /// <returns></returns>
        public async static Task<SmartMeterDevice> RegisterDeviceAsync(string enrollmentKey, string idScope, string deviceId)
        {
            var globalEndpoint = "global.azure-devices-provisioning.net";
            SmartMeterDevice device = null;

            //TODO: 1. Derive a device key from a combination of the group enrollment key and the device id
            //var primaryKey = ...

            //TODO: 2. Create symmetric key with the generated primary key
            //using (var security = ...
            using (var transportHandler = new ProvisioningTransportHandlerMqtt())
            {
                //TODO: 3. Create a Provisioning Device Client
                //var client = ...

                //TODO: 4. Register the device using the symmetric key and MQTT
                //DeviceRegistrationResult result = ...

                //TODO: 5. Populate the device provisioning details
                //device = new SmartMeterDevice()...             
            }

            //return the device
            return device;
        }

        /// <summary>
        /// Compute a symmetric key for the provisioned device from the enrollment group symmetric key used in attestation.
        /// </summary>
        /// <param name="enrollmentKey">Enrollment group symmetric key.</param>
        /// <param name="deviceId">The device Id of the key to create.</param>
        /// <returns>The key for the specified device Id registration in the enrollment group.</returns>
        /// <seealso>
        /// https://docs.microsoft.com/en-us/azure/iot-edge/how-to-auto-provision-symmetric-keys?view=iotedge-2018-06#derive-a-device-key
        /// </seealso>
        private static string ComputeDerivedSymmetricKey(string enrollmentKey, string deviceId)
        {
            if (string.IsNullOrWhiteSpace(enrollmentKey))
            {
                return enrollmentKey;
            }

            var key = "";
            using (var hmac = new HMACSHA256(Convert.FromBase64String(enrollmentKey)))
            {
                key = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(deviceId)));
            }

            return key;
        }

        /// <summary>
        /// Add certificate in local cert store for use by downstream devices
        /// client for secure connection to IoT Edge runtime.
        ///
        ///    Note: On Windows machines, if you have not run this from an Administrator prompt,
        ///    a prompt will likely come up to confirm the installation of the certificate.
        ///    This usually happens the first time a certificate will be installed.
        /// </summary>
        public static void InstallCACert()
        {
            //TODO: 12 - Install and trust IoT Edge Gateway root certificate
            //string trustedCACertPath = ...
        }
    }

}