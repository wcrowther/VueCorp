
import { useHead } from '@unhead/vue'

export function SetHtmlHeadBody()
{
	const appStore      = useAppStore()
	const { altTheme }	= storeToRefs(appStore)

	// Uses UnHead to set base class in <html> so all elements, 
	// including scrollbars are under theme
	// Hard-coded theme variable for now

	const theme = computed(() => altTheme.value ? 'alt-theme': 'theme')
	useHead({ htmlAttrs: { class: theme } })
}

/* EXAMPLE CODE: SetHtmlHeadBody() */