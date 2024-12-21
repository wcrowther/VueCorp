
import { onMounted, onUnmounted } from 'vue'

export function KeyboardListeners(keys)
{
  const addKeyListeners     = () => document.addEventListener('keydown', keys, false)
  const removeKeyListeners  = () => document.removeEventListener('keydown', keys, false)
  
  onMounted(()   => addKeyListeners())
  onUnmounted(() => removeKeyListeners())
}

/*
  import { KeyboardListeners } from './helpers/KeyboardListeners'

  const keys = function (e)   // EXAMPLE LOGIC
  {
        // console.log(e.code);    
        if      (e.code === 'ArrowUp')   { listPager.value.goToPrevious();     e.preventDefault();}
        else if (e.code === 'ArrowDown') { listPager.value.goToNext();         e.preventDefault();}
        else if (e.code === 'Home')      { listPager.value.goToFirstPage();    e.preventDefault();}
        else if (e.code === 'End')       { listPager.value.goToLastPage();     e.preventDefault();}
        else if (e.code === 'PageDown')  { listPager.value.goToPreviousPage(); e.preventDefault();}
        else if (e.code === 'PageUp')    { listPager.value.goToNextPage();     e.preventDefault();} 
  }

  KeyboardListeners(keys);
*/