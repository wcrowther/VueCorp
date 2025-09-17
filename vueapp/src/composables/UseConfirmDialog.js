
// Use to create a ConfirmDialog instance and show it when needed
// Returns a function that can be called to show the dialog and await the result

import { createApp, h } from 'vue'
import ConfirmDialog from '@/components/misc/ConfirmDialog.vue'

let appInstance; // To store the mounted app instance

export function useConfirmDialog() 
{
	if (!appInstance) 
	{
		const el = document.createElement('div');

		document.body.appendChild(el);
		appInstance = createApp({
			render() 
			{
				return h(ConfirmDialog, { ref: 'ConfirmDialog' });
			},
		}).mount(el);
	}

	const fnShowConfirm = async (message) => 
	{
		return await appInstance.$refs.ConfirmDialog.showDialog(message);
	};

	return { fnShowConfirm };
}

/* Example::

	const { showConfirm } = useConfirmDialog();

    const handleDelete = async () => 
    {
        const confirmed = await showConfirm('Are you sure you want to delete this item?');
		...
	}

*/