﻿using SFML.System;
using View = SFML.Graphics.View;

namespace EldenBingo.Rendering
{
    public class LerpCamera : ICamera
    {
        private Vector2f _position, _size;
        private Vector2f _targetPosition;
        private float _zoom;
        private float _targetZoom;
        private View? _view;

        private bool _snap;

        const float DTCHANGE = 2.0f;

        public LerpCamera(Vector2f position, Vector2f size, float zoom)
        {
            _position = position;
            _targetPosition = position;
            _zoom = zoom;
            _targetZoom = zoom;
            Size = size;
        }

        public void Snap()
        {
            _snap = true;
        }

        /// <summary>
        /// True if this camera has changed
        /// </summary>
        public bool Changed { get; private set; }

        /// <summary>
        /// Center position of camera
        /// </summary>
        public virtual Vector2f Position
        {
            get => _position;
            set
            {
                if (_targetPosition != value)
                {
                    _targetPosition = value;
                    Changed = true;
                }
            }
        }

        public Vector2f Size
        {
            get => _size;
            set
            {
                if (_size != value)
                {
                    _size = value;
                    Changed = true;
                }
            }
        }

        public float Zoom
        {
            get => _zoom;
            set
            {
                if (_targetZoom != value)
                {
                    _targetZoom = value;
                    Changed = true;
                }
            }
        }

        public void Update(float dt)
        {
            if (_snap)
            {
                snapToTarget();
            }
            else
            {
                //Never slerp past the target
                var d = (float)Math.Min(1.0, DTCHANGE * dt);

                _position += (_targetPosition - _position) * d;
                _zoom += (_targetZoom - _zoom) * d;
                Changed = true;
            }
        }

        public View GetView()
        {
            if (Changed || _view == null)
            {
                _view = new View(Position, Size);
                _view.Zoom(_zoom);
                Changed = false;
            }
            return _view;
        }

        private void snapToTarget()
        {
            _position = _targetPosition;
            _zoom = _targetZoom;
            Changed = true;
            _snap = false;
        }

    }
}