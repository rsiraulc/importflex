using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages
{
    public class ImportacionesResponse:ResponseBase
    {
        public List<imf_importaciones_imp> lstImportaciones { get; set; }
    }
}