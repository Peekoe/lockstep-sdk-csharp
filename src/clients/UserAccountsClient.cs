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

public class UserAccountsClient
{
    private readonly LockstepApi client;

    public UserAccountsClient(LockstepApi client) {
        this.client = client;
    }

    /// <summary>
    /// Retrieves the User with this identifier.
    /// 
    /// A User represents a person who has the ability to authenticate against the Lockstep Platform and use services such as Lockstep Insights.  A User is uniquely identified by an Azure identity, and each user must have an email address defined within their account.  All Users must validate their email to make use of Lockstep platform services.  Users may have different privileges and access control rights within the Lockstep Platform.
    /// 
    /// </summary>
    /// <param name="id">The unique ID number of the User to retrieve</param>
    /// <param name="include">To fetch additional data on this object, specify the list of elements to retrieve. Available collections: Notes, Attachments, CustomFields, AccountingRole</param>
    public async Task<LockstepResponse<UserAccountModel>> RetrieveUser(Guid id, string include)
    {
        var url = $"/api/v1/UserAccounts/{id}";
        var options = new Dictionary<string, object>();
        options["include"] = include;
        return await this.client.Request<UserAccountModel>(Method.GET, url, options, null);
    }

    /// <summary>
    /// Updates a User that matches the specified id with the requested information.
    /// 
    /// The PATCH method allows you to change specific values on the object while leaving other values alone.  As input you should supply a list of field names and new values.  If you do not provide the name of a field, that field will remain unchanged.  This allows you to ensure that you are only updating the specific fields desired.  A User represents a person who has the ability to authenticate against the Lockstep Platform and use services such as Lockstep Insights.  A User is uniquely identified by an Azure identity, and each user must have an email address defined within their account.  All Users must validate their email to make use of Lockstep platform services.  Users may have different privileges and access control rights within the Lockstep Platform.
    /// 
    /// </summary>
    /// <param name="id">The unique ID number of the User to retrieve</param>
    /// <param name="body">A list of changes to apply to this User</param>
    public async Task<LockstepResponse<UserAccountModel>> UpdateUser(Guid id, object body)
    {
        var url = $"/api/v1/UserAccounts/{id}";
        return await this.client.Request<UserAccountModel>(Method.PATCH, url, null, body);
    }

    /// <summary>
    /// Disable the user referred to by this unique identifier.
    /// 
    /// A User represents a person who has the ability to authenticate against the Lockstep Platform and use services such as Lockstep Insights.  A User is uniquely identified by an Azure identity, and each user must have an email address defined within their account.  All Users must validate their email to make use of Lockstep platform services.  Users may have different privileges and access control rights within the Lockstep Platform.
    /// 
    /// </summary>
    /// <param name="id">The unique Lockstep Platform ID number of this User</param>
    public async Task<LockstepResponse<ActionResultModel>> DisableUser(Guid id)
    {
        var url = $"/api/v1/UserAccounts/{id}";
        return await this.client.Request<ActionResultModel>(Method.DELETE, url, null, null);
    }

    /// <summary>
    /// Reenable the user referred to by this unique identifier.
    /// 
    /// A User represents a person who has the ability to authenticate against the Lockstep Platform and use services such as Lockstep Insights.  A User is uniquely identified by an Azure identity, and each user must have an email address defined within their account.  All Users must validate their email to make use of Lockstep platform services.  Users may have different privileges and access control rights within the Lockstep Platform.
    /// 
    /// </summary>
    /// <param name="id">The unique Lockstep Platform ID number of this User</param>
    public async Task<LockstepResponse<ActionResultModel>> ReenableUser(Guid id)
    {
        var url = $"/api/v1/UserAccounts/reenable";
        var options = new Dictionary<string, object>();
        options["id"] = id;
        return await this.client.Request<ActionResultModel>(Method.POST, url, options, null);
    }

    /// <summary>
    /// Invite a user with the specified email to join your accounting group. The user will receive an email to set up their account.
    /// 
    /// A User represents a person who has the ability to authenticate against the Lockstep Platform and use services such as Lockstep Insights.  A User is uniquely identified by an Azure identity, and each user must have an email address defined within their account.  All Users must validate their email to make use of Lockstep platform services.  Users may have different privileges and access control rights within the Lockstep Platform.
    /// 
    /// </summary>
    /// <param name="body">The user to invite</param>
    public async Task<LockstepResponse<InviteModel[]>> InviteUser(InviteSubmitModel[] body)
    {
        var url = $"/api/v1/UserAccounts/invite";
        return await this.client.Request<InviteModel[]>(Method.POST, url, null, body);
    }

    /// <summary>
    /// Retrieves invite information for the specified invite token.
    /// 
    /// A User represents a person who has the ability to authenticate against the Lockstep Platform and use services such as Lockstep Insights.  A User is uniquely identified by an Azure identity, and each user must have an email address defined within their account.  All Users must validate their email to make use of Lockstep platform services.  Users may have different privileges and access control rights within the Lockstep Platform.
    /// </summary>
    /// <param name="code">The code of the invite</param>
    public async Task<LockstepResponse<InviteDataModel>> RetrieveInviteData(Guid code)
    {
        var url = $"/api/v1/UserAccounts/invite";
        var options = new Dictionary<string, object>();
        options["code"] = code;
        return await this.client.Request<InviteDataModel>(Method.GET, url, options, null);
    }

    /// <summary>
    /// Transfer the ownership of a group to another user. This API must be called by the current owner of the group.
    /// 
    /// A User represents a person who has the ability to authenticate against the Lockstep Platform and use services such as Lockstep Insights.  A User is uniquely identified by an Azure identity, and each user must have an email address defined within their account.  All Users must validate their email to make use of Lockstep platform services.  Users may have different privileges and access control rights within the Lockstep Platform.
    /// 
    /// </summary>
    /// <param name="body"></param>
    public async Task<LockstepResponse<TransferOwnerModel>> TransferOwner(TransferOwnerSubmitModel body)
    {
        var url = $"/api/v1/UserAccounts/transfer-owner";
        return await this.client.Request<TransferOwnerModel>(Method.POST, url, null, body);
    }

    /// <summary>
    /// Queries Users for this account using the specified filtering, sorting, nested fetch, and pagination rules requested. A User represents a person who has the ability to authenticate against the Lockstep Platform and use services such as Lockstep Insights.  A User is uniquely identified by an Azure identity, and each user must have an email address defined within their account.  All Users must validate their email to make use of Lockstep platform services.  Users may have different privileges and access control rights within the Lockstep Platform.
    /// 
    /// </summary>
    /// <param name="filter">The filter for this query. See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    /// <param name="include">To fetch additional data on this object, specify the list of elements to retrieve. Available collections: Notes, Attachments, CustomFields, AccountingRole</param>
    /// <param name="order">The sort order for this query. See See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    /// <param name="pageSize">The page size for results (default 200). See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    /// <param name="pageNumber">The page number for results (default 0). See [Searchlight Query Language](https://developer.lockstep.io/docs/querying-with-searchlight)</param>
    public async Task<LockstepResponse<FetchResult<UserAccountModel>>> QueryUsers(string filter, string include, string order, int pageSize, int pageNumber)
    {
        var url = $"/api/v1/UserAccounts/query";
        var options = new Dictionary<string, object>();
        options["filter"] = filter;
        options["include"] = include;
        options["order"] = order;
        options["pageSize"] = pageSize;
        options["pageNumber"] = pageNumber;
        return await this.client.Request<FetchResult<UserAccountModel>>(Method.GET, url, options, null);
    }
}
