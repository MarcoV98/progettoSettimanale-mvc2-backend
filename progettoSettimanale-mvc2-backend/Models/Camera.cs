using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace progettoSettimanale_mvc2_backend.Models
{
    public class Camera
    {
        public int IdCamera { get; set; }
        public int NumeroCamera { get; set; }
        public bool CameraSingola { get; set; }
        public bool CameraDoppia { get; set; }
        public string DescrizioneCamera { get; set; }
        public int IdCliente { get; set; }
        public Camera() { }
        public Camera(int numeroCamera, bool cameraSingola, bool cameraDoppia, string descrizioneCamera, int idCliente)
        {

            NumeroCamera = numeroCamera;
            CameraSingola = cameraSingola;
            CameraDoppia = cameraDoppia;
            DescrizioneCamera = descrizioneCamera;
            IdCliente = idCliente;
        }
    }
}