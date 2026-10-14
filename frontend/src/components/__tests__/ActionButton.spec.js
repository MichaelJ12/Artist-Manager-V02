import { mount } from '@vue/test-utils'
import { describe, expect, it } from 'vitest'
import ActionButton from '../ActionButton.vue'

describe('ActionButton', () => {
  it('renders the label and button props', () => {
    // Arrange
    const wrapper = mount(ActionButton, {
      props: {
        label: 'Delete artwork',
        type: 'submit',
        color: 'red',
        customClass: 'wide-button',
      },
    })

    // Act
    const button = wrapper.get('button')

    // Assert
    expect(button.text()).toBe('Delete artwork')
    expect(button.attributes('type')).toBe('submit')
    expect(button.classes()).toContain('bg-red-400')
    expect(button.classes()).toContain('wide-button')
  })

  it('emits a click event when clicked', async () => {
    // Arrange
    const wrapper = mount(ActionButton, {
      props: { label: 'Save artwork' },
    })

    // Act
    await wrapper.get('button').trigger('click')

    // Assert
    expect(wrapper.emitted('click')).toHaveLength(1)
    expect(wrapper.emitted('click')[0]).toEqual([])
  })
})
