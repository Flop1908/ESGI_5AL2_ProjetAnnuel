//
//  COmmentCellView.h
//  A&D
//
//  Created by Kapi on 25/03/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import <UIKit/UIKit.h>
//Pas sur
#import "CommentWrapper.h"

@interface CommentCellView : UIView {

	CommentWrapper *commentWrapper;
	UITextView * replyTextView;
	CGPoint gestureStartPoint;
}

@property (nonatomic, retain) CommentWrapper *commentWrapper;
@property (nonatomic, retain) UITextView *replyTextView;

- (void)drawLinkButtons;

@end
