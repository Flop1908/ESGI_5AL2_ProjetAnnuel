using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Tools
{
    internal class ToolBox
    {
        public static string Transcoding(string message, Encoding depart, Encoding destination)
        {
            //transformation du message avec l'encodage de départ en bytes
            byte[] msgBytes = depart.GetBytes(message);
            //application du changement d'encodage
            byte[] isoBytes = Encoding.Convert(depart, destination, msgBytes);
            //transformation des bytes nouvellement encodés en string
            return destination.GetString(isoBytes);
        }
    }
}
