
export const useUsersStore = defineStore('UsersStore',
{
    state: () => 
    ({
        usersPager:      new PagerModel(),
        usersList:       [],
        user:            new UserModel(),
        detailUserId:    0
    }),
    getters:{},
    actions:
    {
        addNewUser()
        {
            this.user = new UserModel()
        },
        async getPagedUsers (pager)
        {
            try 
            {
                console.log('--- >>> Get UsersList From Server')
                
                const result = await apiPost(`/users/getPagedUsers`, pager)
                
                if(result.success) 
                {
                    this.usersPager  = Object.assign(new PagerModel(), result.data.Pager)
                    this.usersList   = result.data.ListItems   
                }
            }
            catch (err){ useMessageStore().showError(err.message) }
        },
        async getUserDetailData (userId)
        {
            try 
            {
                if(userId && userId > 0)
                {
                    const result = await apiGet(`/users/getUserById/${userId}`)
                    
                    if(result.success) 
                        this.user = result.data
                }
            } 
            catch (err) {  useMessageStore().showError(err.message) }
        },
        async saveUser ()
        {
            try 
            {
                const result = await apiPost(`/users/saveUser/`, this.user)

                if(result.success) 
                {
                    this.user = result.data

                    console.log('User Saved Succesfully.')
                    useMessageStore().showSuccess('User Saved Successfully.')
                }
            } 
            catch (err)
            { 
                useMessageStore().showError(err.message) 
            }
        }
    }
})

