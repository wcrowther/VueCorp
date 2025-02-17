
import { onMounted, onUnmounted } from 'vue'

const authStore     	= useAuthStore()
const { refreshAuth }   = authStore
const { authUser  } 	= storeToRefs(authStore)

export function AutoRefreshToken()
{
	let interval = null

	const refreshToken = () =>
	{
		let authRefreshRequest = new AuthRefreshRequest(authUser.value.UserId)
		refreshAuth(authRefreshRequest)
	}

    // Lifecycle & Watches  ==========================================================================

	onMounted(() =>    
	{        
		// Auto-refresh every 'autoRefreshMinutes' every minutes 14 minutes if token expires in 15 minutes
		interval = setInterval(refreshToken, authStore.autoRefreshMinutes * 60 * 1000);
	})

	onUnmounted(() => 
	{
		if (interval) clearInterval(interval);
	});
}
