using System;
using System.Collections.Generic;
using MelonLoader;
using UnityEngine;
using UnityEngine.Events;

namespace Fatury
{
	// Token: 0x0200001C RID: 28
	public class FrameAnimation : MonoBehaviour
	{
		// Token: 0x060000DB RID: 219 RVA: 0x00006F46 File Offset: 0x00005146
		public FrameAnimation(IntPtr intPtr) : base(intPtr)
		{
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00006F61 File Offset: 0x00005161
		public void OnComplete(UnityAction _event)
		{
			this.onComplete = _event;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00006F6A File Offset: 0x0000516A
		public void SetEndEvent(UnityAction _event)
		{
			this.EndEvent = _event;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00006F73 File Offset: 0x00005173
		public void SetCircleEvent(UnityAction _event)
		{
			this.CircleEvent = _event;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00006F7C File Offset: 0x0000517C
		private void Start()
		{
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00006F80 File Offset: 0x00005180
		private void Update()
		{
			if (FrameAnimation.play)
			{
				GameObject gameObject = GameObject.Find(CommonData.currentspritename);
				this.spriterenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
				if ((float)Time.frameCount % (30f / FrameAnimation.Framerate) == 0f)
				{
					this.currentFrameIndex++;
				}
				if (this.currentFrameIndex >= FrameAnimation.image_list.Count)
				{
					this.SequenceRule();
					this.currentFrameIndex = 0;
					UnityAction circleEvent = this.CircleEvent;
					if (circleEvent != null)
					{
						circleEvent.Invoke();
					}
					UnityAction unityAction = this.onComplete;
					if (unityAction != null)
					{
						unityAction.Invoke();
					}
					if (this.onComplete != null)
					{
						this.onComplete = null;
					}
					UnityAction change_event = this.Change_event;
					if (change_event != null)
					{
						change_event.Invoke();
					}
					if (!FrameAnimation.loop && this.SequenceID == -1)
					{
						this.status = FrameAnimation.anim_status.stop;
						this.currentFrameIndex = FrameAnimation.image_list.Count - 1;
					}
				}
				if (FrameAnimation.image_list.Count != 0)
				{
					this.spriterenderer.sprite = FrameAnimation.image_list[this.currentFrameIndex];
					return;
				}
				MelonDebug.Msg("动画序列帧为空！");
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00007091 File Offset: 0x00005291
		private void OnDestroy()
		{
			Object.Destroy(base.GetComponent<FrameAnimation>());
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000709E File Offset: 0x0000529E
		public void ClearSequence()
		{
			this.status = FrameAnimation.anim_status.stop;
			FrameAnimation.image_list.Clear();
			this.Sequence.Clear();
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000070BC File Offset: 0x000052BC
		private void SequenceRule()
		{
			if (this.SequenceID != -1)
			{
				if (this.SequenceID < this.Sequence.Count - 1)
				{
					FrameAnimation.image_list.Clear();
					this.SequenceID++;
					this.Sequence[this.SequenceID].ForEach(delegate(Sprite i)
					{
						FrameAnimation.image_list.Add(i);
					});
					return;
				}
				this.SequenceID = -1;
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000713C File Offset: 0x0000533C
		public void AnimPlaySequence(List<List<Sprite>> _sequence)
		{
			this.ClearSequence();
			this.SequenceID = 0;
			this.currentFrameIndex = 0;
			foreach (List<Sprite> item in _sequence)
			{
				this.Sequence.Add(item);
			}
			this.Sequence[0].ForEach(delegate(Sprite i)
			{
				FrameAnimation.image_list.Add(i);
			});
			this.spriterenderer.sprite = FrameAnimation.image_list[0];
			FrameAnimation.loop = true;
			this.status = FrameAnimation.anim_status.running;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000071F8 File Offset: 0x000053F8
		public void AnimPlay(List<Sprite> _list, SpriteRenderer renderer, bool _loop = false, int frame = 0, int delay = 50)
		{
			MelonLogger.Msg("Start playing");
			FrameAnimation.Framerate = (float)(1000 / delay);
			this.ClearSequence();
			this.SequenceID = 0;
			this.currentFrameIndex = 0;
			_list.ForEach(delegate(Sprite i)
			{
				FrameAnimation.image_list.Add(i);
			});
			this.spriterenderer = renderer;
			this.spriterenderer.sprite = FrameAnimation.image_list[0];
			FrameAnimation.loop = _loop;
			this.currentFrameIndex = frame;
			FrameAnimation.play = true;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00007287 File Offset: 0x00005487
		public void AnimPause()
		{
			this.status = FrameAnimation.anim_status.pause;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00007290 File Offset: 0x00005490
		public void AnimContinue()
		{
			this.status = FrameAnimation.anim_status.running;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00007299 File Offset: 0x00005499
		public void AnimReplay()
		{
			this.currentFrameIndex = 0;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000072A2 File Offset: 0x000054A2
		public void AnimStop()
		{
			this.status = FrameAnimation.anim_status.stop;
			this.currentFrameIndex = 0;
			UnityAction endEvent = this.EndEvent;
			if (endEvent == null)
			{
				return;
			}
			endEvent.Invoke();
		}

		// Token: 0x04000050 RID: 80
		public static bool play = false;

		// Token: 0x04000051 RID: 81
		public static List<Sprite> image_list = new List<Sprite>();

		// Token: 0x04000052 RID: 82
		public List<List<Sprite>> Sequence = new List<List<Sprite>>();

		// Token: 0x04000053 RID: 83
		protected int SequenceID = -1;

		// Token: 0x04000054 RID: 84
		protected static bool loop = true;

		// Token: 0x04000055 RID: 85
		protected FrameAnimation.anim_status status;

		// Token: 0x04000056 RID: 86
		protected UnityAction onComplete;

		// Token: 0x04000057 RID: 87
		private SpriteRenderer spriterenderer;

		// Token: 0x04000058 RID: 88
		protected UnityAction EndEvent;

		// Token: 0x04000059 RID: 89
		protected UnityAction CircleEvent;

		// Token: 0x0400005A RID: 90
		protected UnityAction Change_event;

		// Token: 0x0400005B RID: 91
		private int currentFrameIndex;

		// Token: 0x0400005C RID: 92
		private static float Framerate = 20f;

		// Token: 0x02000037 RID: 55
		protected enum anim_status
		{
			// Token: 0x04000081 RID: 129
			unstart,
			// Token: 0x04000082 RID: 130
			running,
			// Token: 0x04000083 RID: 131
			pause,
			// Token: 0x04000084 RID: 132
			stop
		}
	}
}
