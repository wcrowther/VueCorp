
export const useAuthStore = defineStore('AuthStore',
{
    state: () => 
    ({
        authUser:       useLocalStorage('authUser', {}),
        isBusy:         false,
        error:          '',
        returnUrl:      '/'
    }),
    getters:
    {
        isLoggedIn:     (state) => 
        {
           return (state.authUser && state.authUser.Token && state.authUser.Token.length > 0) ? true : false
        },
        userName:       (state) => state.authUser.FirstName || 'UserName',
        firstInitial:   (state) => state.authUser.FirstName.charAt(0).toUpperCase() || 'U',
        expiration:     (state) => state.authUser.Expiration || '---'
    },
    actions:
    {
        async login (model)
        {
            try
            {
                const result  = await apiPost(`/authenticate/login`, model)

                if(result.success) 
                {
                    this.authUser = result.data
                    this.router.push(this.returnUrl)
                    this.returnUrl = '/'  // reset
                }
            }
            catch(err)
            {
                useMessageStore().showError(err.message)   
            }
        },
        async signup (model)
        {
            try
            {
                const result  = await apiPost(`/authenticate/Signup`, model)

                if(result.success) 
                {
                    this.authUser = result.data
                    this.router.push(this.returnUrl)
                    this.returnUrl = '/'
                }
            }
            catch(err)
            {   
                useMessageStore().showError(err.message)   
            }
        },
        async logout (route)
        {
            this.authUser = {}
            this.router.push(route || '/login')
        }
    }
})


// ======================================================================================
// ALTERNATE SYNTAX EXAMPLE
// ======================================================================================
// async loginAlt (model)
// {
//    try 
//    {
//        this.isBusy         = true
//     
//        let queryUrl        = `${baseApiUrl}/authenticate/`
//        const result        = await axios.post(queryUrl, model, this.axiosConfig )
//        this.authUser       = result.data
// 
//        console.log("--- >>> Logging In - authUser")
//        console.log(JSON.parse(JSON.stringify(this.authUser))) 
// 
//        this.router.push('/')
//    } 
//    catch (err) 
//    { 
//        console.error(err) 
//        this.error = err
//    }
//    finally { this.isBusy = false }
// },

