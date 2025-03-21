
const messageStore  = useMessageStore()

export const useImagesStore = defineStore('ImagesStore',
{
    state: () => 
    ({
        imagesPager:        new PagerModel(),
        imagesList:         [],
        imageDetail:        {},
        detailImageName:    ''
    }),
    getters:{},
    actions:
    {
        async getPagedImages (pager)
        {
            try 
            {
                console.log('--- Get Paged Images From Server')
                // logJson('getPagedImages request', JSON.stringify(pager))
               
                const result = await apiPost(`/content/getPagedImages`, pager)
                
                if(result.success) 
                {
                    this.imagesPager  = Object.assign(new PagerModel(), result.data.Result.Pager)
                    this.imagesList   = result.data.Result.ListItems   
                }
            }
            catch (err)
            { 
                messageStore.showError(err.message) 
            }
        },
        async getImageDetailData (imageName)
        {
           alert(`getImageDetailData Not Implemented: ${imageName}`)

            // try 
            // {
            //     if(accountId && accountId > 0)
            //     {
            //         console.log(`------- Get AccountDetail ${accountId} From Server`)
            //         
            //         const result = await apiGet(`/accounts/getAccountById/${accountId}`)
            //         
            //         if(result.success) 
            //             this.account = result.data.Result
            //     }
            // } 
            // catch (err) {  messageStore.showError(err.message) }
        }
    }
})
