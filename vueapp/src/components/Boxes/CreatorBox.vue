<script setup>

    const props = defineProps (
    {
        IAuditable:  
        { 
            type: Object, 
            required: true,
            validator(value){
                const requiredFields = ["DateCreated", "DateModified", "CreatorId", "ModifierId"];
                for (const prop of requiredFields) {
                    if (!Object.hasOwn(value, prop)) {
                        console.log(`CreatorBox does not implement: ${prop}`);
                    }
                }
                return true;
            }
        } 
    })

    const { DateCreated, CreatorId,  DateModified, ModifierId } = props.IAuditable;

</script>

<template>

    <div class="-m-5 mb-5 p-3 flex flex-wrap gap-2 justify-between
        text-slate-400 whitespace-nowrap text-xs italic overflow-hidden">
        <span :title="`Modified: ${dateTimeFormat(DateModified)}  by Will Crowther ${ModifierId}`">
            Modified: {{dateFormat(DateModified)}} 
        </span>
        <span :title="`Created: ${dateTimeFormat(DateCreated)} by Will Crowther ${CreatorId}`">
            Created: {{dateFormat(DateCreated)}}
        </span> 
    </div>

</template>


<!-- 
USE:  Wrap around creator data to give consistent visual impact.
EXAMPLE: 
    <CreatorBox v-if="!isAddingAccount" :IAuditable="account" />
-->


