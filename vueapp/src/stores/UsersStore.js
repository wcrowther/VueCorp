
const messageStore  = useMessageStore()

export const useUsersStore = defineStore('UsersStore',
{
    state: () => 
    ({
        usersPager:      new Pager(),
        usersList:       [],
        user:            {},
        detailUserId:    0
    }),
    getters:{},
    actions:
    {
        addNewUser()
        {
            this.user = new User()
        },
        async getPagedUsers (pager)
        {
            try 
            {
                log('--- >>> Get UsersList From Server')
                
                const result = await apiPost(`/users/getPagedUsers`, pager)
                
                if(result.success) 
                {
                    this.usersPager  = Object.assign(new Pager(), result.data.Pager)
                    this.usersList   = result.data.ListItems   
                }
            }
            catch (err){ messageStore.showError(err.message) }
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
            catch (err) {  messageStore.showError(err.message) }
        },
        async saveUser ()
        {
            try 
            {
                log('Save User!')
                
                const result = await apiPost(`/users/saveUser/`, this.user)

                if(result.success) 
                {
                    this.user = result.data

                    log('User Saved Succesfully.')
                    messageStore.showSuccess('User Saved Successfully.')
                }
            } 
            catch (err)
            { 
                messageStore.showError(err.message) 
            }
        }
    }
})

