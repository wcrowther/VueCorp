
const messageStore  = useMessageStore()

export const useAccountsStore = defineStore('AccountsStore',
{
    state: () => 
    ({
        accountsPager:      new Pager(),
        accountsList:       [],
        account:            {},
        detailAccountId:    0
    }),
    getters:{},
    actions:
    {
        addNewAccount()
        {
            this.account = new Account()
        },
        async getPagedAccounts (pager)
        {
            try 
            {
                log('--- >>> Get AccountList From Server')
                
                const result = await apiPost(`/accounts/getPagedAccounts`, pager)
                
                if(result.success) 
                {
                    this.accountsPager  = Object.assign(new Pager(), result.data.Pager)
                    this.accountsList   = result.data.ListItems   
                }
            }
            catch (err){ messageStore.showError(err.message) }
        },
        async getAccountDetailData (accountId)
        {
            try 
            {
                if(accountId && accountId > 0)
                {
                    const result = await apiGet(`/accounts/getAccountById/${accountId}`)
                    
                    if(result.success) 
                        this.account = result.data
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
                    this.account = result.data

                    log('Account Saved Succesfully.')
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
//         this.accountsPager    = Object.assign(new Pager(), result.data.pager)
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