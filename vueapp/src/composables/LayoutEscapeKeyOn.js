
export function LayoutEscapeKey(boolValue)
{	
	const appStore   			= useAppStore()
    const { layoutEscapeKeyOn }	= storeToRefs(appStore)

	// console.log(`layoutEscapeKeyOn: ${boolValue}`)
	
	onMounted(() =>   { layoutEscapeKeyOn.value   = boolValue })
	onUnmounted(() => { layoutEscapeKeyOn.value = !boolValue });
}

/* EXAMPLE CODE:

	import { LayoutEscapeKey } from './helpers/LayoutEscapeKey.js'
	LayoutEscapeKey(false);
*/