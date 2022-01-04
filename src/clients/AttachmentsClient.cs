/***
 * Lockstep Software Development Kit for C#
 *
 * (c) 2021-2022 Lockstep, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author     Ted Spence <tspence@lockstep.io>
 * @copyright  2021-2022 Lockstep, Inc.
 * @version    2021.39
 * @link       https://github.com/Lockstep-Network/lockstep-sdk-csharp
 */

namespace LockstepSDK;



using RestSharp;

public class AttachmentsClient
{
    private readonly LockstepApi client;

    public AttachmentsClient(LockstepApi client) {
        this.client = client;
    }

    /// <summary>
    /// Retrieves the Attachment with the provided Attachment identifier.
    /// 
    /// An Attachment is a file that can be attached to various account attributes within Lockstep. Attachments can be used for invoices, bills, or any other external files that you wish to track and have access to. Attachments represents an Attachment and a number of different metadata attributes related to the creation, storage, and ownership of the Attachment.
    /// 
    /// See [Extensibility](https://developer.lockstep.io/docs/extensibility) for more information.
    /// 
    /// </summary>
    /// <param name="id">The unique ID number of the Attachment to retrieve</param>
    /// <param name="include">To fetch additional data on this object, specify the list of elements to retrieve. No collections are currently available for querying but may be available in the future.</param>
    public async Task<LockstepResponse<AttachmentModel>> RetrieveAttachment(Guid id, string include)
    {
        var url = $"/api/v1/Attachments/{id}";
        var options = new Dictionary<string, object>();
        options["include"] = include;
        return await this.client.Request<AttachmentModel>(Method.GET, url, options, null);
    }

    /// <summary>
    /// Updates an existing Attachment with the information supplied to this PATCH call.
    /// 
    /// The PATCH method allows you to change specific values on the object while leaving other values alone.  As input you should supply a list of field names and new values.  If you do not provide the name of a field, that field will remain unchanged.  This allows you to ensure that you are only updating the specific fields desired.
    /// 
    /// An Attachment is a file that can be attached to various account attributes within Lockstep. Attachments can be used for invoices, bills, or any other external files that you wish to track and have access to. Attachments represents an Attachment and a number of different metadata attributes related to the creation, storage, and ownership of the Attachment.
    /// 
    /// See [Extensibility](https://developer.lockstep.io/docs/extensibility) for more information.
    /// 
    /// </summary>
    /// <param name="id">The unique Lockstep Platform ID number of the attachment to update</param>
    /// <param name="body">A list of changes to apply to this Attachment</param>
    public async Task<LockstepResponse<AttachmentModel>> UpdateAttachment(Guid id, object body)
    {
        var url = $"/api/v1/Attachments/{id}";
        return await this.client.Request<AttachmentModel>(Method.PATCH, url, null, body);
    }

    /// <summary>
    /// Flag this attachment as archived, which can distinguish between attachments currently active and attachments not intended for active use.  This is similar to deletion but preserves information about the record's existence.
    /// 
    /// An Attachment is a file that can be attached to various account attributes within Lockstep. Attachments can be used for invoices, bills, or any other external files that you wish to track and have access to. Attachments represents an Attachment and a number of different metadata attributes related to the creation, storage, and ownership of the Attachment.
    /// 
    /// See [Extensibility](https://developer.lockstep.io/docs/extensibility) for more information.
    /// 
    /// </summary>
    /// <param name="id">The unique ID number of the Attachment to be archived</param>
    public async Task<LockstepResponse<ActionResultModel>> ArchiveAttachment(Guid id)
    {
        var url = $"/api/v1/Attachments/{id}";
        return await this.client.Request<ActionResultModel>(Method.DELETE, url, null, null);
    }

    /// <summary>
    /// Returns a URI for the Attachment file to be downloaded, based on the ID provided.
    /// 
    /// An Attachment is a file that can be attached to various account attributes within Lockstep. Attachments can be used for invoices, bills, or any other external files that you wish to track and have access to. Attachments represents an Attachment and a number of different metadata attributes related to the creation, storage, and ownership of the Attachment.
    /// 
    /// See [Extensibility](https://developer.lockstep.io/docs/extensibility) for more information.
    /// 
    /// </summary>
    /// <param name="id">The unique ID number of the Attachment whose URI will be returned</param>
    public async Task<LockstepResponse<string>> DownloadAttachment(Guid id)
    {
        var url = $"/api/v1/Attachments/{id}/download";
        return await this.client.Request<string>(Method.GET, url, null, null);
    }

    /// <summary>
    /// Uploads and creates one or more Attachments from the provided arguments.
    /// 
    /// An Attachment is a file that can be attached to various account attributes within Lockstep. Attachments can be used for invoices, bills, or any other external files that you wish to track and have access to. Attachments represents an Attachment and a number of different metadata attributes related to the creation, storage, and ownership of the Attachment.
    /// 
    /// See [Extensibility](https://developer.lockstep.io/docs/extensibility) for more information.
    /// 
    /// </summary>
    /// <param name="tableName">The name of the type of object to which this Attachment will be linked</param>
    /// <param name="objectId">The unique ID of the object to which this Attachment will be linked</param>
    public async Task<LockstepResponse<AttachmentModel[]>> UploadAttachment(string tableName, Guid objectId)
    {
        var url = $"/api/v1/Attachments";
        var options = new Dictionary<string, object>();
        options["tableName"] = tableName;
        options["objectId"] = objectId;
        return await this.client.Request<AttachmentModel[]>(Method.POST, url, options, null);
    }

    /// <summary>
    /// Queries Attachments for this account using the specified filtering, sorting, nested fetch, and pagination rules requested.
    /// 
    /// More information on querying can be found on the [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight) page on the Lockstep Developer website.
    /// 
    /// An Attachment is a file that can be attached to various account attributes within Lockstep. Attachments can be used for invoices, bills, or any other external files that you wish to track and have access to. Attachments represents an Attachment and a number of different metadata attributes related to the creation, storage, and ownership of the Attachment.
    /// 
    /// See [Extensibility](https://developer.lockstep.io/docs/extensibility) for more information.
    /// 
    /// </summary>
    /// <param name="filter">The filter to use to select from the list of available Attachments, in the [Searchlight query syntax](https://github.com/tspence/csharp-searchlight).</param>
    /// <param name="include">To fetch additional data on this object, specify the list of elements to retrieve. No collections are currently available for querying but may be available in the future.</param>
    /// <param name="order">The sort order for the results, in the [Searchlight order syntax](https://github.com/tspence/csharp-searchlight).</param>
    /// <param name="pageSize">The page size for results (default 200, maximum of 10,000)</param>
    /// <param name="pageNumber">The page number for results (default 0)</param>
    public async Task<LockstepResponse<FetchResult<AttachmentModel>>> QueryAttachments(string filter, string include, string order, int pageSize, int pageNumber)
    {
        var url = $"/api/v1/Attachments/query";
        var options = new Dictionary<string, object>();
        options["filter"] = filter;
        options["include"] = include;
        options["order"] = order;
        options["pageSize"] = pageSize;
        options["pageNumber"] = pageNumber;
        return await this.client.Request<FetchResult<AttachmentModel>>(Method.GET, url, options, null);
    }
}
