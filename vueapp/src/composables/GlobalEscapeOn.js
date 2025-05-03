
export function GlobalEscapeOn(boolValue)
{	
	const appStore   			= useAppStore()
    const { globalEscapeOn }	= storeToRefs(appStore)

	console.log(`globalEscapeOn: ${boolValue}`)
	
	onMounted(() =>   { globalEscapeOn.value   = boolValue })
	onUnmounted(() => { globalEscapeOn.value = !boolValue });
}

/* EXAMPLE CODE:

	import { GlobalEscapeOn } from './helpers/GlobalEscapeOn.js'
	GlobalEscapeOn(false);
*/