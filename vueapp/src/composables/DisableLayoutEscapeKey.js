
export function DisableLayoutEscapeKey()
{	
	const appStore   			= useAppStore()
    const { layoutEscapeKeyOn }	= storeToRefs(appStore)

	onMounted(() =>   { layoutEscapeKeyOn.value  = false; })
	onUnmounted(() => { layoutEscapeKeyOn.value  = true; })
}

/* 	USAGE: 
	EXAMPLE CODE:

	import { DisableLayoutEscapeKey } from './helpers/DisableLayoutEscapeKey.js'
	DisableLayoutEscapeKey();
*/