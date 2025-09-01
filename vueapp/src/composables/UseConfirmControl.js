
const showConfirm 		= ref(false)
const confirmMessage 	= ref('')
let resolver 			= null

export default function useConfirm() 
{
	async function confirm(msg) 
	{
		confirmMessage.value = msg
		showConfirm.value 	 = true

		return new Promise((resolve) => 
		{
			resolver = resolve
		})
	}

	function onConfirm() 
	{
		showConfirm.value = false
		resolver?.(true)
	}

	function onCancel() 
	{
		showConfirm.value = false
		resolver?.(false)
	}

	return {
		showConfirm,
		confirmMessage,
		confirm,
		onConfirm,
		onCancel
	}
}
