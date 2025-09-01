import { onBeforeRouteLeave } from 'vue-router'
import { onMounted, onBeforeUnmount } from 'vue'

export function useUnsavedChangesGuard(isDirtyRef, confirmFn) 
{
	// Internal helper
	async function checkConfirm() 
	{
		if (isDirtyRef.value) {
			// call your custom confirm dialog instead of window.confirm
			return await confirmFn('You have unsaved changes. Continue?')
		}
		return true
	}

	// 1. Guard against route changes
	onBeforeRouteLeave(async (to, from, next) => 
	{
		const ok = await checkConfirm()
		if (ok) 
			next()
		else 
			next(false)
	})

	// 2. Guard against browser close / refresh
	function handleBeforeUnload(e) 
	{
		if (isDirtyRef.value) 
		{
			e.preventDefault()
			e.returnValue = '' // Chrome requires this
		}
	}

	onMounted(() => {
		window.addEventListener('beforeunload', handleBeforeUnload)
	})

	onBeforeUnmount(() => {
		window.removeEventListener('beforeunload', handleBeforeUnload)
	})
}
