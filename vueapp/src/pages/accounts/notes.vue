<script setup>

    const pageTitle  = ref('Account Notes')
    // const isTop      = ref(true)

</script>

<template>

    <div class="relative" id="adminNotes">

        <div class="z-0 bg-gradient-main h-[500px] absolute top-0 left-0 right-0"></div>

        <div class="z-20 p-5 pt-5 sm:p-10 sm:pt-5 pb-14">
            <div class="flex justify-between items-center mb-7 relative">
                <h2 class="text-2xl font-display font-bold flex-grow">{{ pageTitle }}</h2>
                <span class="flex flex-wrap gap-1.5">
                    <!-- <button class="btn-primary" >Add</button>-->
                </span>
            </div>
            <div class="w-full min-h-[400px] relative">
                
                <InfoBox>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. 
                    Voluptates accusamus repudiandae quam officiis temporibus dicta ipsa iure? 
                    Iusto dicta nulla error. Fugit aspernatur odit voluptate, quo libero id minus.
                </InfoBox>
            
                <HelpBox>
                    Voluptates accusamus repudiandae quam officiis temporibus dicta ipsa iure? 
                    Iusto dicta nulla error. Fugit aspernatur odit voluptate, quo libero id minus.
                </HelpBox>

                <!-- <GridControl  />

                <FloaterControl :show="true" name="FloaterOne" 
                    class="bg-white w-[400px] h-[300px] p-5">
                    Some floating content here.
                </FloaterControl>

                <WizardControl class="mb-10" :tabList="['First', 'Second', 'Third']" >

                    <template #First>       
                        <div class="p-5 border border-black font-bold mb-3">First Content</div>
                    </template>
                
                    <template #Second>       
                        <div class="p-5 border border-black font-bold mb-3">Second Content</div>
                    </template>
                
                    <template #Third>       
                        <div class="p-5 border border-black font-bold text-red mb-3">Important</div>
                    </template>

                </WizardControl> -->

            </div>

        </div>

        <!--
        <div class="flex pl-5 gap-3">
        
            <IconSymbol class="transition-transform duration-500" :class="{'rotate-[-450deg]': isTop}"
                :color="isTop ? 'green': 'red'" @click="isTop=!isTop" width="96px" icon="mdi:arrow-down-thick" />
        
            <IconSymbol width="96px" :inline="false" :vertical-flip="true" 
                color="red" class="border border-red" icon="mdi:arrow-down-box" />
        
            <div class="bg-red contents h-fit w-fit">
                <IconSymbol class="" width="96px" icon="heroicons:academic-cap-16-solid" />
            </div> 

        </div>
         -->
    </div>  
</template>