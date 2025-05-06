
const messageStore  = useMessageStore()

export const useAccountsStore = defineStore('AccountsStore',
{
    state: () => 
    ({
        accountsPager:      new PagerModel(new SearchForAccount()),
        accountsList:       [],
        account:            {},
        detailAccountId:    0
    }),
    getters:{},
    actions:
    {
        addNewAccount()
        {
            this.account = new AccountModel()
        },
        async getPagedAccounts (pager)
        {
            try 
            {
                console.log('--- Get AccountList From Server')
                // logJson('getPagedAccounts request', JSON.stringify(pager))
               
                const result = await apiPost(`/accounts/getPagedAccounts`, pager)
                
                if(result.success) 
                {
                    this.accountsPager  = Object.assign(new PagerModel(new SearchForAccount()), result.data.Result.Pager)
                    this.accountsList   = result.data.Result.ListItems   
                }
            }
            catch (err)
            { 
                messageStore.showError(err.message) 
            }
        },
        async getAccountDetailData (accountId)
        {
            try 
            {
                if(accountId && accountId > 0)
                {
                    console.log(`------- Get AccountDetail ${accountId} From Server`)
                    
                    const result = await apiGet(`/accounts/getAccountById/${accountId}`)
                    
                    if(result.success) 
                        this.account = result.data.Result
                }
            } 
            catch (err) {  messageStore.showError(err.message) }
        },
        async saveAccount ()
        {
            try 
            {
                const result = await apiPost(`/accounts/saveAccount/`, this.account)

                if(result.success) 
                {
                    this.account = result.data.Result

                    messageStore.showSuccess('Account Saved Successfully.')
                }
            } 
            catch (err){ messageStore.showError(err.message) }
        }
    }
})



// =======================================================================================
// ALTERNATE SYNTAX
// =======================================================================================
// {
//     console.log('getPagedAccounts: ') 
//     
//     this.isBusy  = true
//     let queryUrl = `${baseApiUrl}/accounts/getPagedAccounts`
// 
//     axios.post(queryUrl, pager, axiosConfig) 
//     .then((result) => 
//     {
//         this.accountsPager    = Object.assign(new PagerModel(), result.data.pager)
//         this.accountsList     = result.data.listItems // NOTE: casing of listItems  
// 
//         console.log(JSON.parse(JSON.stringify(this.accountsPager))) 
//         console.log(JSON.parse(JSON.stringify(this.accountsList))) 
//     })
//     .catch((err) => 
//     {
//         console.error(err) 
//         this.error = err
//     })
//     .finally(() => { this.isBusy = false })
// },
// =======================================================================================