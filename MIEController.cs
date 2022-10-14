using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pocblueprint.api.Features.DownLoadFromBlob;
using pocblueprint.api.Features.ExcelImport;
using pocblueprint.api.Features.ExportToExcel;
using pocblueprint.api.Features.MIE;
using pocblueprint.api.Features.MIE.GetAllMaterials;
using pocblueprint.api.Features.MIE.GetMaterailbyIdUsingSp;
using pocblueprint.api.Features.MIE.InsertData;
using pocblueprint.api.Features.MIE.UpdateData;
using pocblueprint.api.Features.SendMail;
using pocblueprint.api.Features.UploadToBlob;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pocblueprint.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MIEController : ControllerBase
    {       
        private readonly ILogger<MIEController> _logger;
        private readonly IMediator _mediator;
        public MIEController(ILogger<MIEController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("getall")]
        public async Task<List<MaterialEntityResponse>> GetAll()
        {          
            return await _mediator.Send(new EmptyRequest());
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("getmaterialbyid")]
        public async Task<GetMaterialbyIdResponse> GetMaterialbyId([FromQuery] GetMaterialbyIdRequest getMaterialbyIdRequest)
        {
            return await _mediator.Send(getMaterialbyIdRequest);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("exportexcel")]
        public async Task<FileStreamResult> ExportToExcel()
        {
            ExportMaterialEntityRequest _exportMaterialEntityRequest = new ExportMaterialEntityRequest();
            var data = await _mediator.Send(_exportMaterialEntityRequest);
             return File(
                data.FileStream,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: data.DownLoadFileName);
         }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("downloadfromblob")]
        public async Task<FileStreamResult> DownLoadFromBlob(DownLoadFromBlobRequest downLoadFromBlob)
        {            
            DownLoadFromBlobResponse downLoadFromBlobResponse = await _mediator.Send(downLoadFromBlob);
            return File(
                downLoadFromBlobResponse.FileStream,
                contentType: downLoadFromBlobResponse.ContentType,
                fileDownloadName: downLoadFromBlobResponse.DownLoadFileName);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("uploadtoblob")]
        public async Task<UploadToBlobResponse> UploadToBlob(IFormFile formFile)
        {
            UploadToBlobRequest uploadToBlobRequest = new UploadToBlobRequest();
            uploadToBlobRequest.formFile = formFile;
            return await _mediator.Send(uploadToBlobRequest); 
        }
      
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("exceltolist")]
        public async Task<List<ImportEntityResponse>> ExcelToList(IFormFile file)
        {
            ImportMaterialEntityRequest importMaterialEntityRequest = new ImportMaterialEntityRequest();
            importMaterialEntityRequest.formFile = file;
            return await _mediator.Send(importMaterialEntityRequest);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("sendmail")]
        public async Task<bool> SendMail()
        {
            SendMailEmptyRequest sendMailEmptyRequest = new SendMailEmptyRequest();
            return await _mediator.Send(sendMailEmptyRequest);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("getmaterialbyidusingsp")]
        public async Task<GetMaterialbyIdResponseUsingSp> GetMaterialbyIdUsingSp([FromQuery] GetMaterialbyIdRequestUsingSp getMaterialbyIdRequestUsingSp)
        {
            return await _mediator.Send(getMaterialbyIdRequestUsingSp);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("Insertdata")]
        public async Task<InsertDataResponse> Insertdata([FromBody] InsertDataRequest insertDataRequest)
        {
            return await _mediator.Send(insertDataRequest);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("updatedata")]
        public async Task<UpdateDataResponse> updatedata([FromBody] UpdateDataRequest updateDataRequest)
        {
            return await _mediator.Send(updateDataRequest);
        }
    }
}
