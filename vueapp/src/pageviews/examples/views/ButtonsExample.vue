<script setup>

    // OTHER BUTTON DEMOS
    const boolValue         = ref(false)
    const switchValue       = ref(false)
    const rotateOpen        = ref(false)

</script>

<template>

    <div class="w-full">

        <PageTitleBox pageTitle="Button Examples" />

        <InfoBox>
            The <b>/components/buttons</b> folder has a set of small, focused button components covering 
            styled actions, boolean toggles, and array navigation. Each demo below is labeled with what it's 
            used for - the <b>ListButton</b> demos live in the sidebar to the right.
        </InfoBox>

        <HelpBox>
            <div class="mb-3">
                <b>Right-click to reverse:</b> <b>ListButton</b> and <b>InfoButton</b> both bind their 
                right-click to step backward, so you never need a separate "previous" button.
            </div>
            <div class="mb-3">
                <b>InfoButton drives this page:</b> the demo below is the real, global help-level toggle - 
                click it (or right-click it) and watch this <b>HelpBox</b> and the <b>InfoBox</b> above 
                react, since both are just <code>v-if="infoLevel > ..."</code> wrappers.
            </div>
            <div>
                <b>Container-aware capsule:</b> the bordered row below uses the <b>v-container-width</b> 
                debug directive (see <code>@/helpers/ContainerWidth</code>) to show which Tailwind 
                <code>@container</code> tier each side currently occupies.
            </div>
        </HelpBox>
        
        <div class="flex flex-wrap gap-[10px] @container" v-container-width>

            <div class="w-full @xl:flex-1 flex flex-col gap-6 mb-5">

                <div>
                    <div class="font-bold mb-1">PrimaryButton / SecondaryButton</div>
                    <p class="mb-2">Standard styled buttons for primary and secondary actions.</p>
                    <div class="flex gap-3">
                        <PrimaryButton>Click Me</PrimaryButton>
                        <SecondaryButton title="Click Me" />
                    </div>
                </div>

                <div>
                    <div class="font-bold mb-1">BooleanButton</div>
                    <p class="mb-2">Toggles a boolean <code>v-model</code>, optionally showing different text/icon for each state.</p>
                    <BooleanButton v-model="boolValue" trueText="On" falseText="Off" class="px-3 w-[72px]"
                        trueIcon="heroicons-solid:check" falseIcon="heroicons-solid:x" />
                </div>

                <div>
                    <div class="font-bold mb-1">SwitchButton</div>
                    <p class="mb-2">An iOS-style switch bound to a boolean <code>v-model</code>.</p>
                    <SwitchButton buttonName="Active" class="bg-orange text-white" v-model="switchValue" />
                </div>

                <div>
                    <div class="font-bold mb-1">RotateButton</div>
                    <p class="mb-2">Rotates an icon to reflect a boolean state - handy for collapsible panels.</p>
                    <RotateButton v-model="rotateOpen" icon="heroicons:chevron-down-solid" rotation="rotate-180" />
                </div>

                <div>
                    <div class="font-bold mb-1">InfoButton</div>
                    <p class="mb-2">Cycles the app's global help level (None / Info / Help) - this is the real toggle, 
                        so watch the <b>InfoBox</b> and <b>HelpBox</b> above react.</p>
                    <InfoButton />
                </div>

            </div>

            <div class="w-full @xl:flex-1 p-5 pb-7 border border-blue">
                <ListButtonExample />                
            </div>  

        </div>

    </div>

</template>