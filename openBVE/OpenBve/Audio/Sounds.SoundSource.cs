﻿namespace OpenBve {
	internal static partial class Sounds {
		
		/// <summary>Represents the state of a sound source.</summary>
		internal enum SoundSourceState {
			/// <summary>The sound will start playing once in audible range. The OpenAL sound name is not yet valid.</summary>
			PlayPending,
			/// <summary>The sound is playing and the OpenAL source name is valid.</summary>
			Playing,
			/// <summary>The sound will stop playing. The OpenAL sound name is still valid.</summary>
			StopPending,
			/// <summary>The sound has stopped and will be removed from the list of sound sources. The OpenAL source name is not valid any longer.</summary>
			Stopped
		}
		
		/// <summary>Represents a sound source.</summary>
		internal class SoundSource {
			// --- members ---
			/// <summary>The sound buffer.</summary>
			internal SoundBuffer Buffer;
			/// <summary>The effective sound radius.</summary>
			internal double Radius;
			/// <summary>The pitch change factor.</summary>
			internal double Pitch;
			/// <summary>The volume change factor.</summary>
			internal double Volume;
			/// <summary>The position. If a train and car are specified, the position is relative to the car, otherwise absolute.</summary>
			internal OpenBveApi.Math.Vector3 Position;
			/// <summary>The train this sound is attached to, or a null reference.</summary>
			internal TrainManager.Train Train;
			/// <summary>The car this sound is attached to, or a null reference.</summary>
			internal int Car;
			/// <summary>Whether this sound plays in a loop.</summary>
			internal bool Looped;
			/// <summary>The current state of the sound. Determines if the OpenAL sound name is valid.</summary>
			internal SoundSourceState State;
			/// <summary>The OpenAL source name. Only valid if the sound is playing.</summary>
			internal int OpenAlSourceName;
			// --- constructors ---
			/// <summary>Creates a new sound source.</summary>
			/// <param name="buffer">The sound buffer.</param>
			/// <param name="radius">The effective sound radius.</param>
			/// <param name="pitch">The pitch change factor.</param>
			/// <param name="volume">The volume change factor.</param>
			/// <param name="position">The position. If a train and car are specified, the position is relative to the car, otherwise absolute.</param>
			/// <param name="train">The train this sound source is attached to, or a null reference.</param>
			/// <param name="car">The car this sound source is attached to, or a null reference.</param>
			/// <param name="looped">Whether this sound source plays in a loop.</param>
			internal SoundSource(SoundBuffer buffer, double radius, double pitch, double volume, OpenBveApi.Math.Vector3 position, TrainManager.Train train, int car, bool looped) {
				this.Buffer = buffer;
				this.Radius = radius;
				this.Pitch = pitch;
				this.Volume = volume;
				this.Position = position;
				this.Train = train;
				this.Car = car;
				this.Looped = looped;
				this.State = SoundSourceState.PlayPending;
				this.OpenAlSourceName = 0;
			}
			// --- functions ---
			/// <summary>Stops this sound.</summary>
			internal void Stop() {
				if (this.State == SoundSourceState.PlayPending) {
					this.State = SoundSourceState.Stopped;
				} else if (this.State == SoundSourceState.Playing) {
					this.State = SoundSourceState.StopPending;
				}
			}
		}
		
	}
}