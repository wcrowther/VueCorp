
import axios from 'axios'

export async function apiGet(url){ return apiCall('GET',  url, true)  }
export async function apiPost(url, body){ return apiCall('POST', url, true, body) }

// ==================================================================================

export async function apiCall(type, url, useAuth, body) 
{
	const appStore     	= useAppStore()
	const authStore     = useAuthStore()
	const messageStore  = useMessageStore()

	let result 		= 
	{
		message: 		'',
		toastType:	 	'ERROR',
		success: 		false,
		error: 			{}
	}

	let callOptions =  
	{
		baseURL: 	appStore.baseApiUrl,
		url:		url,
		method: 	`${type}`, // POST, GET, etc
		headers: 	{}
	}	

	log(`apiCall: ${type} (useAuth: ${useAuth}) from Url: ${url}`)

	if (body) 
	{
		logJson('apiCall', JSON.stringify(body))

		callOptions.headers['Content-Type'] = 'application/json'
		callOptions.data = JSON.stringify(body)
	}

	if (!!useAuth === true && authStore.authUser && authStore.authUser.Token) 
	{
		callOptions.headers['Authorization'] = `Bearer ${authStore.authUser.Token}`
	}

	try 
	{
		result 			= await axios(callOptions)
		result.success	= true
	} 
	catch (err) 
	{
		result.error = err

		if(err.code === 'ERR_NETWORK')
		{
			result.message 		= 'Not able to communicate with the server. Please try again later.'
		}
		else if ([400].includes(err.response.status)) 
		{
			result.message 		= err.response.data.detail || err.message || err.response.data.error 
			result.toastType 	= 'INFO'
		}		
		else if ([401].includes(err.response.status)) // 401 - Unauthorized (unauthenticated)
		{
			authStore.logout()
			result.message 	= "You are not authorized for that content.\nPlease login to gain access."
			result.toastType 	= 'INFO'
		}		
		else if ([403].includes(err.response.status)) // Forbidden (known but does not have rights to content)
		{
			authStore.logout()
			result.message 		= "The username or password you entered is incorrect."
			result.toastType 	= 'INFO'
		} 
		else
		{
			result.message = err.message
		}

		messageStore.showToast(result.message, result.toastType)   
	}

	return result
}

// ==================================================================================
// EXAMPLE CODE: 
// ==================================================================================
// const result      = await apiGet(`/accounts/getAccountById/${accountId}`)
// this.account      = result.data
// ==================================================================================

