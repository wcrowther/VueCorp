
<script setup>

    // import { ref, reactive, onMounted, computed } from 'vue'

    const props = defineProps(
    {
        url:            { type: String, required: true      },
        height:         { type: String, default: '400px'    },
		width:          { type: String, default: '600px'    },
        initialWait:    { type: Number, default: 1000       },
        wait:           { type: Number, default: 2000       },
        duration:       { type: Number, default: 15000      },
        zoom1:          { type: String, default: '100%'     },  
        zoom2:          { type: String, default: '250%'     },
        position1:      { type: String, default: 'center'   },  
        position2:      { type: String, default: '80% 50%'  }          
    })

    const zoomIn	        = ref(false)
    const toggleZoom        = () => zoomIn.value = !zoomIn.value
    const totalDuration     = computed(() => props.duration + props.wait ) 

    const animation         = reactive(
    { 
        backgroundImage:        `url('${props.url}')`,
        height:                 props.height,
        width:                  props.width,
        transitionDuration:     `${props.duration}ms`,
        backgroundSize:         computed(() => zoomIn.value ? props.zoom2 : props.zoom1 ),
		backgroundPosition:     computed(() => zoomIn.value ? props.position2 : props.position1 )
    })

	onMounted(() => 
	{ 
        setTimeout(function()
        {
            toggleZoom()
			window.setInterval(toggleZoom, totalDuration.value)

		}, props.initialWait)
	})

</script>

<template>

	<div class="bg-no-repeat transition-all text-white relative" :style="animation" >        
		<!-- <span class="p-1 pl-2 inline-block">{{zoomIn ? 'ZoomIn': 'ZoomOut'}}</span> -->
	</div>

</template>
